using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Diagnostics;
using Miniproject.Models;
using ControlzEx.Standard;

namespace Miniproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string openApiUri = "https://apis.data.go.kr/6260000/AttractionService/getAttractionKr?serviceKey=ZWzY%2BaXaAxa6uaINctI3EjRA4kcyYOoPzwebpFlGhuvk3PQCHkyn6CLNtMHN7NyVoMUFEVub1%2BCzXExqMR3YoQ%3D%3D&pageNo=1&numOfRows=10&resultType=json";
            string result = string.Empty;

            WebRequest req = null;  
            WebResponse res = null; 
            StreamReader reader = null;

            try
            {
                req = WebRequest.Create(openApiUri);
                res = await req.GetResponseAsync();
                reader = new StreamReader(res.GetResponseStream());
                result = reader.ReadToEnd();

                //await this.ShowMessageAsync("결과", result);
                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("오류", $"OpenAPI 조회오류 {ex.Message}");
            }

            var jsonResult = JObject.Parse(result);
            var header = jsonResult["getAttractionKr"]["header"];
            var code = Convert.ToInt32(header["code"]);

            if (code == 00)
            {
                var data = jsonResult["getAttractionKr"]["item"];
                var jsonArray = data as JArray; // json자체에서 []안에 들어간 배열데이터만 JArray 변환가능

                var attraction = new List<Attraction>();
                foreach (var item in jsonArray)
                {
                    attraction.Add(new Attraction()
                    {
                        
                        MAIN_TITLE = Convert.ToString(item["main_title"]),
                        GUGUN_NM = Convert.ToString(item["gugun_nm"]),
                        LAT = Convert.ToDouble(item["lat"]),
                        LNG = Convert.ToDouble(item["lng"]),
                        PLACE = Convert.ToString(item["place"]),
                        TITLE = Convert.ToString(item["title"]),
                        SUBTITLE = Convert.ToString(item["subtitle"]),
                        ADDR1 = Convert.ToString(item["addr1"]),
                        CNTCT_TEL = Convert.ToString(item["cntct_tel"]),
                        HOMEPAGE_URL = Convert.ToString(item["homepage_url"]),
                        TRFC_INFO = Convert.ToString(item["trfc_info"]),
                        USAGE_AMOUNT = Convert.ToString(item["usage_amount"]),
                        MIDDLE_SIZE_RM1 = Convert.ToString(item["middle_size_rm1"]),
                        ITEMCNTNTS = Convert.ToString(item["itemcntnts"]),
                    });
                }
                this.DataContext = attraction;
                StsResult.Content = $"OpenAPI {attraction.Count}건 조회완료!";
            }
        }
        private void TxtAttactionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSearch_Click(sender, e); // 검색 버튼클릭 이벤트핸들러 실행
            }
        }
    }
}