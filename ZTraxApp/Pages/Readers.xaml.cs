using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ZTraxApp.Models;
using ZTraxApp.ViewModels;

namespace ZTraxApp.Pages
{
    /// <summary>
    /// Interaction logic for Devices.xaml
    /// </summary>
    public partial class Readers : Page
    {
        ReadersViewModel ViewModel;

        public Readers()
        {
            InitializeComponent();
            ViewModel = new ReadersViewModel();
            this.DataContext = ViewModel;
        }

        RFIDReader CribRfidReader = new RFIDReader();

        private Dictionary<string, bool> HostnameIsReading = new Dictionary<string, bool>();

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //fill out singulation combobox options
            comboBoxSingulation.Items.Add(SESSION.SESSION_S0);
            comboBoxSingulation.Items.Add(SESSION.SESSION_S1);
            comboBoxSingulation.Items.Add(SESSION.SESSION_S2);
            comboBoxSingulation.Items.Add(SESSION.SESSION_S3);

            comboBoxSingulation.SelectedIndex = 1; //default session is S1
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Content.ToString() == "Connect") //if button says "Connect", which implies its disconnected, then try to connect
            {
                //set RFID object to correct
                CribRfidReader.HostName = textBoxCribHostName.Text;
                CribRfidReader.Port = 5084;

                try
                {
                    //connect to reader
                    CribRfidReader.Connect();

                    //fill out antenna combobox
                    numericUpDownAntenna.NumValue = 1; //can assume RFID device always has 1 antenna
                    numericUpDownAntenna.NumValue = CribRfidReader.Config.Antennas.Length; //restrict antenna selection based on how many antennas are on device

                    //fill out antenna dbm power values combobox
                    numericUpDownPower.NumValue = CribRfidReader.ReaderCapabilities.TransmitPowerLevelValues[0]; //this is lowest parameter you will pass to my SetAntennaPower method
                    numericUpDownPower.NumValue = CribRfidReader.ReaderCapabilities.TransmitPowerLevelValues[CribRfidReader.ReaderCapabilities.TransmitPowerLevelValues.Length - 1]; //this is highest parameter you will pass to my SetAntennaPower method
                    //numericUpDownPower.Increment = 10;
                    numericUpDownPower.NumValue = 2500;

                    //enable GPI events
                    CribRfidReader.Events.NotifyGPIEvent = true;
                    CribRfidReader.Events.NotifyReaderDisconnectEvent = true;
                    CribRfidReader.Events.NotifyReaderExceptionEvent = true;

                    //set the singulation equal to whats in the combobox
                    comboBoxSingulation_SelectedValueChanged(null, null);

                    //subscribe to both read and GPIO events
                    //CribRfidReader.Events.ReadNotify += Events_ReadNotify;
                    //CribRfidReader.Events.StatusNotify += Events_StatusNotify;

                    //update connection status
                    //toolStripConnectionStatusLabel.Text = "Connected to " + CribRfidReader.HostName;

                    //change text button
                    buttonConnect.Content = "Disconnect";

                    //dataGridViewTags.DataSource = tags;
                    //this was originally in the events_statusNofity area.
                    // ConfigureRfidReadToSensor();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Unable to connect to reader. Exc=" + exc.ToString());
                    return;
                }
            }
            else if (buttonConnect.Content.ToString() == "Disconnect")  //if button says "Disconnect", which implies its connected, then try to disconnect
            {
                try
                {
                    //disconnect from reader
                    CribRfidReader.Disconnect();

                    //update connection status
                    //toolStripConnectionStatusLabel.Text = "Disconnected";

                    //change text button
                    buttonConnect.Content = "Connect";
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Unable to disconnect from reader. Exc=" + exc.ToString());
                    return;
                }
            }
        }

        private void buttonApplyPower_Click(object sender, EventArgs e)
        {
            string antennaID = numericUpDownAntenna.NumValue.ToString();
            string txValue = numericUpDownPower.NumValue.ToString();
            SetAntennaPower(CribRfidReader, int.Parse(antennaID), int.Parse(txValue));
        }

        private void SetAntennaPower(RFIDReader reader, int antennaNumber, int transmitPower)
        {
            try
            {
                Antennas.Config myconfig = reader.Config.Antennas[antennaNumber].GetConfig(); //get the configuration object of respective antenna

                ushort txPowerIndex = (ushort)Array.FindIndex<int>(reader.ReaderCapabilities.TransmitPowerLevelValues, element => element == transmitPower); //get the index of the selected transmitpower, and set the transmit propertypowerindex property to apply antenna power change
                myconfig.TransmitPowerIndex = txPowerIndex; //this takes the index of the value (not the value itself) to set the antenna power
                reader.Config.Antennas[antennaNumber].SetConfig(myconfig); //apply config change to respective antenna
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            //DisplayAntennaTransmitPowerValues(reader); //this simply brings up a messagebox that display each antenna transmitpowervalue so it is easy to visualize
        }

        private void comboBoxSingulation_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CribRfidReader.IsConnected) //only takes affect if reader is connected
            {
                Antennas.SingulationControl sc = new Antennas.SingulationControl();
                sc.Session = (SESSION)comboBoxSingulation.SelectedItem;
                foreach (ushort ant in CribRfidReader.Config.Antennas.AvailableAntennas)
                {
                    CribRfidReader.Config.Antennas[ant].SetSingulationControl(sc);
                }
            }
        }


        public bool GetIsReadingByHostname(string hostname)
        {
            if (HostnameIsReading.ContainsKey(hostname)) //if dictionary contains this hostname already
            {
                return HostnameIsReading[hostname];
            }
            else
            {
                return false;
            }
        }

        //public void ConnectReader(RFIDReader rfidReader)
        //{
        //    try
        //    {
        //        //connect to reader
        //        rfidReader.Connect();

        //        Console.WriteLine("Reader{0} successfully connected", rfidReader.HostName);

        //        //enable GPI events
        //        rfidReader.Events.NotifyGPIEvent = true;
        //        rfidReader.Events.NotifyReaderDisconnectEvent = true;
        //        rfidReader.Events.NotifyReaderExceptionEvent = true;
        //        rfidReader.Events.NotifyInventoryStartEvent = true;
        //        rfidReader.Events.NotifyInventoryStopEvent = true;

        //        //set the singulation for reader to SESSION1 (read once, limit # of tag reads)
        //        SetSingulation(rfidReader, SESSION.SESSION_S1);

        //        //subscribe to both read and GPIO events
        //        rfidReader.Events.ReadNotify += Events_ReadNotifyEE;
        //        rfidReader.Events.StatusNotify += Events_StatusNotify1;

        //        //max the antenna strength for reader
        //        for (int i = 1; i <= rfidReader.Config.Antennas.Length; i++)
        //        {
        //            SetAntennaPower(rfidReader, i, 3000);//set antenna strength to max; antenna start at index=1 (not 0);
        //        }

        //        RefreshReadersList();
        //    }
        //    catch (Symbol.RFID3.OperationFailureException rfidExc)
        //    {
        //        Console.WriteLine("Unable to connect to  reader. Exc=" + rfidExc.ToString());
        //    }
        //    catch (Exception exc)
        //    {
        //        Console.WriteLine("Unable to connect to  reader. Exc=" + exc.ToString());
        //    }
        //}

        ////for each tag read event from the EE reader (CHANGING THIS TO HANDLE ALL READ EVENTS FROM ALL READERS outside of the crib room
        //private void Events_ReadNotifyEE(object sender, EventArgs e)
        //{
        //    //find out what reader triggered this read event
        //    Symbol.RFID3.Events.ReadEventArgs tag = (Symbol.RFID3.Events.ReadEventArgs)sender;
        //    Symbol.RFID3.Events host = (Symbol.RFID3.Events)sender;
        //    string hostName = host.HostName;
        //    string tagId = tag.ReadEventData.TagData.TagID; //grab the ID of tag
        //    string last6 = "N/A";

        //    System.Diagnostics.Debug.WriteLine("Reader={0}, Tag={1}, Time={2}", hostName, tagId, DateTime.Now);

        //    if (tagId.Length == 24) //only grab these tags
        //    {

        //        last6 = tagId.Substring(18); //get the last 6 characters of tag ID (this is the barcodeID/assetID in infoline)

        //        System.Diagnostics.Debug.WriteLine("****** Last6={0}, Tag={1}, Time={2}", last6, tagId, DateTime.Now);

        //        Tags tempTag = new Tags(tagId, last6, DateTime.Now);
        //        if (IgnoredAssetsList.Contains(tempTag.Last6)) //make sure asset is not on the ignored list (see app.config
        //        {
        //            Console.WriteLine("Asset={0} not processed because it is on ignored list; refer to app.config file", tempTag.Last6);
        //            return;
        //        }

        //        if (Assets.Any(x => x.Barcode == tempTag.Last6)) //if this tag is one of the ones in the Assets list from JSON server
        //        {
        //            if (checkBoxAllEventsEnable.Checked) //make sure all events is enabled
        //            {
        //                //find out last person associate with asset
        //                //get assetID by last6(barcode)
        //                string id_of_asset = Assets.Find(x => x.Barcode == tempTag.Last6).AssetID;
        //                string[] userInfo = JsonRpcWrapper.FindLastUserInfoLinkedToAsset(id_of_asset);
        //                if (userInfo != null)
        //                {
        //                    string lastUserId = userInfo[0];
        //                    string lastUserName = userInfo[1];
        //                    string locName = FindFullLocDescByHostname(hostName);
        //                    string locID = FindLocIDByHostName(hostName);
        //                    //pass this into our already loaded contacts list to get a first and lastname
        //                    string description = String.Format("{0} ({1}) detected asset #={2} on ant#={3}",
        //                                                                    FindShortLocDescByHostname(hostName),
        //                                                                    hostName,
        //                                                                    tempTag.Last6,
        //                                                                    e.ReadEventData.TagData.AntennaID.ToString());
        //                    AddEventToDatabase(new EventLogItem(description,
        //                                                        DateTime.Now,
        //                                                        EventLogItem.EventType.LOCATION_UPDATE,
        //                                                        hostName,
        //                                                        locName,
        //                                                        tempTag.TagId,
        //                                                        tempTag.Last6,
        //                                                        lastUserName.ToUpper(), lastUserId, locID
        //                                                        )); //update this with the last person to check the device out of room
        //                    Log.Information(String.Format("Reader={0} - {1} ({2}) read @ {3}", hostName, tempTag.Last6, tempTag.TagId, tempTag.TimeStamp.ToLongTimeString()));
        //                    Log.Information(id_of_asset);
        //                    JsonRpcWrapper.PostRFIDData(id_of_asset, tempTag.TagId, lastUserName.ToUpper(), locName, hostName, EventLogItem.EventType.LOCATION_UPDATE.ToString(), description, DateTime.Now, lastUserId, locID);
        //                }
        //            }
        //            //Log.Information(String.Format("Reader={0} - {1} ({2}) read @ {3}", hostName, tempTag.Last6, tempTag.TagId, tempTag.TimeStamp.ToLongTimeString()));
        //            //  Log.Information(String.Format("Reader={0} - {1} ({2}) read @ {3}", hostName, tempTag.Last6, tempTag.TagId, tempTag.TimeStamp.ToLongTimeString()));

        //            //at this point, we have the hostname of the reader
        //            //we need to look up the locations" list, match the hostname we have to the hostname column (without *), then find location ID
        //            string dynamicLocationID = FindDynamicLocationIdByHostname(hostName);
        //            string assetId = Assets.Find(p => p.Barcode == last6).AssetID ?? "null"; //gets the ID of an asset by looking in table and finding id; if null, sets id to string null

        //            Console.WriteLine("*** updating tag {0} dynamic location ID to {1}", tempTag.Last6, dynamicLocationID);
        //            // JsonRpcWrapper.UpdateDynamicLocAndDate(Convert.ToInt32(assetId), dynamicLocationID, DateTime.Now); //update location and date
        //        }
        //    }
        //}



    }
}
