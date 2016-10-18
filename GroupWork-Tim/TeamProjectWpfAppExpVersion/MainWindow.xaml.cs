using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeamProjectWpfAppExpVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RESTHandler objRest;
        Response.RootObject myResponse;

        String Description, BuyNow, Price, BidCount, Dealer, Image, Flags, Details;
        List<Response.Group> groupList;
        List<Response.Detail> detailList;

        public MainWindow()
        {
            InitializeComponent();

            PerformOperation();
        }

        public void PerformOperation()
        {
            objRest = new RESTHandler(@"https://extraction.import.io/query/extractor/cc2ec580-d520-44e4-9bd6-0048f8c2f663?_apikey=a759e60c74034f7f839fefaf97502e5a6bc346bf84931f5c90d436954961631a25086cb8866a99ae3dd9f2cf60d7ee0e7586aa58a38c227f1b7eede0b17e03d17c511383803d0abbb81d0d1587392d6a&url=http%3A%2F%2Fwww.trademe.co.nz%2FBrowse%2FSearchResults.aspx%3Fsort_order%3Dbids_asc%26from%3Dadvanced%26advanced%3Dtrue%26searchstring%3D2004%26current%3D0%26cid%3D268%26rptpath%3D1-268-%26searchregion%3D100");

            myResponse = objRest.ExecuteCurrentRequest();

            groupList = myResponse.extractorData.data[0].group;

            List<VehicleListing> Vehicles = new List<VehicleListing>();

            for (int i = 0; i < groupList.Count; i++)
            {
                if (myResponse.extractorData.data[0].group[i].Description != null)
                {
                    Description = myResponse.extractorData.data[0].group[i].Description[0].text;
                }

                if (myResponse.extractorData.data[0].group[i].BuyNow != null)
                {
                    BuyNow = myResponse.extractorData.data[0].group[i].BuyNow[0].text;
                    string[] BuyNowDollars = BuyNow.Split(null);
                    BuyNow = BuyNowDollars[0];
                }


                if (myResponse.extractorData.data[0].group[i].Price != null)
                {
                    Price = myResponse.extractorData.data[0].group[i].Price[0].text;
                }


                if (myResponse.extractorData.data[0].group[i].BidCount != null)
                {
                    BidCount = myResponse.extractorData.data[0].group[i].BidCount[0].text;
                    string[] BidNumbers = BidCount.Split(null);
                    BidCount = BidNumbers[0];
                }


                if (myResponse.extractorData.data[0].group[i].Dealer != null)
                {
                    Dealer = myResponse.extractorData.data[0].group[i].Dealer[0].alt;
                }


                if (myResponse.extractorData.data[0].group[i].Image != null)
                {
                    Image = myResponse.extractorData.data[0].group[i].Image[0].src;
                }


                if (myResponse.extractorData.data[0].group[i].Flags != null)
                {
                    Flags = myResponse.extractorData.data[0].group[i].Flags[0].title;
                }

                //BuyNow = myResponse.extractorData.data[0].group[i].BuyNow[0].text;
                //Price = myResponse.extractorData.data[0].group[i].Price[0].text;
                //BidCount = myResponse.extractorData.data[0].group[i].BidCount[0].text;
                //Dealer = myResponse.extractorData.data[0].group[i].Dealer[0].alt;
                //Image = myResponse.extractorData.data[0].group[i].Image[0].src;
                //Flags = myResponse.extractorData.data[0].group[i].Flags[0].title;

                //Perform details operation
                if (myResponse.extractorData.data[0].group[i].Details != null)
                {

                    detailList = myResponse.extractorData.data[0].group[i].Details;
                    Details = "";

                    for (int y = 0; y < detailList.Count; y++)
                    {
                        String aDetail = myResponse.extractorData.data[0].group[i].Details[y].text;
                        Details = Details + aDetail;
                    }

                    int a = 0;

                    Vehicles.Add(new VehicleListing() { VehicleDescription = Description, VehicleBuyNow = BuyNow, VehiclePrice = Price, VehicleBidCount = BidCount, VehicleDealer = Dealer, VehicleImage = Image, VehicleFlags = Flags, VehicleDetails = Details });

                    dataGrid.ItemsSource = Vehicles;
                }
            }




        }
    }
}


