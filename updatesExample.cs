        //----------------------------------------------------------
        // Private | Update Form State | page_Updates
        //----------------------------------------------------------
        private string update_page_Updates()
        {
            try
            {
                //Only Update if anythings changed
                if (publicProfile.page_Updates.tab_Changed == true)
                {
                    //Access Dispatcher
                    Application.Current.Dispatcher.Invoke(new Action(delegate
                    {
                        //Header Text
                        titleLbl.Content = publicProfile.page_Main.label_HeaderLbl_Text;

                        //----------------------------------------------------------
                        // List | Updates Summary List
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Items
                        updates_SummaryDataGrid.Items.Clear();

                        //Get Devices List
                        foreach(string item in publicProfile.profile_Updates.get_FullUpdatesList())
                        {
                            //Create Device Table
                            UpdateTable updateTable = new UpdateTable();

                            //Set Defaults
                            updateTable.Make = Profiles.Public.string_Unknown;
                            updateTable.Model = Profiles.Public.string_Unknown;
                            updateTable.Name = Profiles.Public.string_Unknown;
                            updateTable.Build = Profiles.Public.string_Unknown;
                            updateTable.Active = Profiles.Public.string_Unknown;

                            //Get Device Name
                            updateTable.Name = OG.Hash.getItemHandle(item, publicProfile.compass_split0);

                            //Create Single Update Ignore Switch
                            bool ignoreSingleUpdate = false;

                                // Loop Device Properties
                                foreach (string subItem in OG.Hash.Convert.rowToList(OG.Hash.getItemBody(item, publicProfile.compass_split0), publicProfile.compass_split1))
                                {
                                    //Get Handle
                                    string subItemHandle = OG.Hash.getItemHandle(subItem, publicProfile.compass_split2).ToLower();

                                    //Make
                                    if (subItemHandle == Profiles.Public.string_Make.ToLower())
                                    {
                                        updateTable.Make = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                        
                                    }
                                    //Model
                                    else if (subItemHandle == Profiles.Public.string_Model.ToLower())
                                    {
                                        updateTable.Model = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Build
                                    else if (subItemHandle == Profiles.Public.string_Build.ToLower())
                                    {
                                        updateTable.Build = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Active
                                    else if (subItemHandle == "active".ToLower())
                                    {
                                        updateTable.Active = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Single Update
                                    else if (subItemHandle == "imei".ToLower())
                                    {
                                        //Check for Single Update
                                        if (OG.Hash.getItemBody(subItem, publicProfile.compass_split2).ToLower() != "none")
                                        {
                                            //Flip Single Update Switch
                                            ignoreSingleUpdate = true;
                                        }
                                    }
                                }

                                if (ignoreSingleUpdate == false)
                                {
                                    //Add Device to Table
                                    updates_SummaryDataGrid.Items.Add(updateTable);
                                }
                            }
                        

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // List | Devices List
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Items
                        updates_DevicesDataGrid.Items.Clear();

                        //Get Devices List
                        foreach (string item in publicProfile.page_Updates_DevicesTab.list_DevicesList_Items)
                        {
                            //Create Device Table
                            DeviceTable deviceTable = new DeviceTable();

                            //Set Defaults
                            deviceTable.Make = Profiles.Public.string_Unknown;
                            deviceTable.Model = Profiles.Public.string_Unknown;
                            deviceTable.IMEI = Profiles.Public.string_Unknown;
                            deviceTable.Build = Profiles.Public.string_Unknown;
                            deviceTable.Date = Profiles.Public.string_Unknown;

                            //Check Root Handle for Item String
                            if (OG.Hash.getItemHandle(item, publicProfile.compass_split0) == Profiles.Public.string_Item)
                            {
                                // Loop Device Properties
                                foreach (string subItem in OG.Hash.Convert.rowToList(OG.Hash.getItemBody(item, publicProfile.compass_split0), publicProfile.compass_split1))
                                {
                                    //Get Handle
                                    string subItemHandle = OG.Hash.getItemHandle(subItem, publicProfile.compass_split2);

                                    //Make
                                    if (subItemHandle == Profiles.Public.string_Make)
                                    {
                                        deviceTable.Make = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Model
                                    else if (subItemHandle == Profiles.Public.string_Model)
                                    {
                                        deviceTable.Model = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //IMEI
                                    else if (subItemHandle == Profiles.Public.string_ImeiMeid)
                                    {
                                        deviceTable.IMEI = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Build
                                    else if (subItemHandle == Profiles.Public.string_Build)
                                    {
                                        deviceTable.Build = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                    //Date
                                    else if (subItemHandle == Profiles.Public.string_Date)
                                    {
                                        deviceTable.Date = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                    }
                                }

                                //Add Device to Table
                                updates_DevicesDataGrid.Items.Add(deviceTable);
                            }
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // List | History List
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Items
                        updates_HistoryDataGrid.Items.Clear();

                        //Get Devices List
                        foreach (string item in publicProfile.page_Updates_HistoryTab.list_HistoryList_Items)
                        {
                            //Create Device Table
                            HistoryTable historyTable = new HistoryTable();

                            //Set Defaults
                            historyTable.Make = publicProfile.page_Updates.string_MakeList_SelectedText;
                            historyTable.Model = publicProfile.page_Updates.string_ModelList_SelectedText;
                            historyTable.IMEI = Profiles.Public.string_Unknown;
                            historyTable.OldBuild = Profiles.Public.string_Unknown;
                            historyTable.NewBuild = Profiles.Public.string_Unknown;
                            historyTable.Date = Profiles.Public.string_Unknown;


                                // Loop Device Properties
                            foreach (string subItem in OG.Hash.Convert.rowToList(OG.Hash.getItemBody(item, publicProfile.compass_split0), publicProfile.compass_split1))
                            {
                                //Get Handle
                                string subItemHandle = OG.Hash.getItemHandle(subItem, publicProfile.compass_split2);

                                //IMEI
                                if (subItemHandle == Profiles.Public.string_IMEI)
                                {
                                    historyTable.IMEI = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                }
                                //Old Build
                                else if (subItemHandle == Profiles.Public.string_OldBuild)
                                {
                                    historyTable.OldBuild = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                }
                                //New Build
                                else if (subItemHandle == Profiles.Public.string_NewBuild)
                                {
                                    historyTable.NewBuild = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                }
                                //Date
                                else if (subItemHandle == Profiles.Public.string_Date.ToLower())
                                {
                                    historyTable.Date = OG.Hash.getItemBody(subItem, publicProfile.compass_split2);
                                }
                            }

                            //Add Device to Table
                            updates_HistoryDataGrid.Items.Add(historyTable);
                            
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // Dropdown List | Make
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Loop Make List
                        foreach (string makeItem in publicProfile.page_Updates.list_MakeList_Items)
                        {
                            //Add if No Exist
                            if (updates_MakeList.Items.Contains(makeItem) == false)
                            {
                                //Add Make
                                updates_MakeList.Items.Add(makeItem);
                            }
                        }

                        // Selected Text
                        updates_MakeList.SelectedItem = publicProfile.page_Updates.string_MakeList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // Dropdown List | Model
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Models
                        updates_ModelList.Items.Clear();

                        //Loop Model List
                        foreach (string modelItem in publicProfile.page_Updates.list_ModelList_Items)
                        {
                            //Add if No Exist
                            if (updates_ModelList.Items.Contains(modelItem) == false)
                            {
                                //Add Model
                                updates_ModelList.Items.Add(modelItem);
                            }
                        }

                        // Selected Text
                        updates_ModelList.SelectedItem = publicProfile.page_Updates.string_ModelList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Image | Device Image
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Image Location
                        

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | Current Builds
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_CurrentBuildsBox.Items.Clear();

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_CurrentBuildsList_Items)
                        {
                            // Add Items
                            updates_CurrentBuildsBox.Items.Add(item);
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | Download Slots
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_CurrentDownloadsBox.Items.Clear();

                        //Create Counter
                        int dlSlotsCounter = 0;

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_DownloadSlotsList_Items)
                        {
                            // Add Items
                            updates_CurrentDownloadsBox.Items.Add(item);
                            dlSlotsCounter = dlSlotsCounter + 1;
                        }

                        //Totals Label
                        updates_DownloadSlotsLbl.Content = "Download Slots (" + dlSlotsCounter.ToString() + " Total)";


                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | Single Update Que
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_OneTimeQueBox.Items.Clear();

                        //Create Counter
                        int suSlotsCounter = 0;

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_SingleUpdatesList_Items)
                        {
                            // Add Items
                            updates_OneTimeQueBox.Items.Add(item);
                            suSlotsCounter = suSlotsCounter + 1;
                        }

                        //Totals Label
                        updates_OneTimeQueLbl.Content = "Single Update Queue (" + suSlotsCounter.ToString() + " Total)";

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Update Profile
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Models
                        updates_UpdateProfileList.Items.Clear();

                        //Loop Model List
                        foreach (string modelItem in publicProfile.page_Updates_UpdatesTab.list_ProfileNameList_Items)
                        {
                            //Add if No Exist
                            if (updates_UpdateProfileList.Items.Contains(modelItem) == false)
                            {
                                //Add Model
                                updates_UpdateProfileList.Items.Add(modelItem);
                            }
                        }

                        // Selected Text
                        updates_UpdateProfileList.SelectedItem = publicProfile.page_Updates_UpdatesTab.string_ProfileNameList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Update Status
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Models
                        updates_UpdateActiveList.Items.Clear();

                        //Loop Model List
                        foreach (string modelItem in publicProfile.page_Updates_UpdatesTab.list_ActiveStatusList_Items)
                        {
                            //Add if No Exist
                            if (updates_UpdateActiveList.Items.Contains(modelItem) == false)
                            {
                                //Add Model
                                updates_UpdateActiveList.Items.Add(modelItem);
                            }
                        }

                        // Selected Text
                        updates_UpdateActiveList.SelectedItem = publicProfile.page_Updates_UpdatesTab.string_ActiveStatusList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Update Build
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Models
                        updates_firmwareBuildBox.Items.Clear();

                        //Loop Model List
                        updates_firmwareBuildBox.Items.Add(publicProfile.page_Updates_UpdatesTab.string_FirmwareBuildList_SelectedText);
                        
                        // Selected Text
                        updates_firmwareBuildBox.Text = publicProfile.page_Updates_UpdatesTab.string_FirmwareBuildList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | IMEI Whitelist
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_whitelistBox.Items.Clear();

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_IMEIWhiteList_Items)
                        {
                            // Add Items
                            updates_whitelistBox.Items.Add(item);
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // Text Box | Upload Whitelist CSV Text
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Set Path Text
                        updates_UploadCSVTxt.Text = publicProfile.page_Updates_UpdatesTab.string_UploadWhitelistCSV_Path;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // Text Box | Upload Blacklist CSV Text
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Set Path Text
                        updates_UploadCSVTxt1.Text = publicProfile.page_Updates_UpdatesTab.string_UploadBlacklistCSV_Path;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | Remove IMEI Whitelist
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_RemoveIMEITxt.Items.Clear();

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_IMEIWhiteList_Items)
                        {
                            // Add Items
                            updates_RemoveIMEITxt.Items.Add(item);
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | IMEI Blacklist
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_blacklistBox.Items.Clear();

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_IMEIBlackList_Items)
                        {
                            // Add Items
                            updates_blacklistBox.Items.Add(item);
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | List | Remove IMEI Blacklist
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        // Items List
                        updates_RemoveIMEITxt1.Items.Clear();

                        // Loop List
                        foreach (string item in publicProfile.page_Updates_UpdatesTab.list_IMEIBlackList_Items)
                        {
                            // Add Items
                            updates_RemoveIMEITxt1.Items.Add(item);
                        }

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Carrier Codes
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Codes
                        updates_CCFilterBox.Items.Clear();

                        //Loop Code List
                        updates_CCFilterBox.Items.Add(publicProfile.page_Updates_UpdatesTab.string_CarrierCodeList_SelectedText);

                        //Selected Text
                        updates_CCFilterBox.Text = publicProfile.page_Updates_UpdatesTab.string_CarrierCodeList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Min Version
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Codes
                        updates_MinVersionBox.Items.Clear();

                        //Loop Code List
                        updates_MinVersionBox.Items.Add(publicProfile.page_Updates_UpdatesTab.string_MinVersionList_SelectedText);

                        //Selected Text
                        updates_MinVersionBox.Text = publicProfile.page_Updates_UpdatesTab.string_MinVersionList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                        //----------------------------------------------------------
                        // UPDATES TAB | Dropdown List | Max Version
                        //----------------------------------------------------------
                        #region
                        //----------------------------------------------------------

                        //Clear Codes
                        updates_MaxVersionBox.Items.Clear();

                        //Loop Code List
                        updates_MaxVersionBox.Items.Add(publicProfile.page_Updates_UpdatesTab.string_MaxVersionList_SelectedText);

                        //Selected Text
                        updates_MaxVersionBox.Text = publicProfile.page_Updates_UpdatesTab.string_MaxVersionList_SelectedText;

                        #endregion
                        //----------------------------------------------------------

                    }));

                    //Flip Switch
                    publicProfile.page_Updates.tab_Changed = false;
                }
                else
                {
                    //Sleep a Sec
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                sendDegbugMessage(ex.ToString());
            }

            return Profiles.Public.string_None;
        }
        //-------------------------------------------------------