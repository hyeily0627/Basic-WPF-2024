using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using ex10_MovieFinder2024.Models;
using System.Windows.Media.Imaging;
using System.Security.AccessControl;

namespace ex10_MovieFinder2024
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

        #region 검색창 내용 입력 후 엔터키 사용시 클릭이벤트 실행 
        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //await this.ShowMessageAsync("검색", "검색을 시작합니다!!");
            if (string.IsNullOrEmpty(TxtMovieName.Text))
            {
                await this.ShowMessageAsync("검색", "검색할 영화명을 입력하세요!!");
                return;
            }

            SearchMovie(TxtMovieName.Text);
        }
        #endregion

        private async void SearchMovie(string movieName)
        {
            string tmdb_apiKey = "1aee496c40c67b8be663601b50f17fb8"; // TMDB사이트에서 제공받은 API키.
            string encoding_movieName = HttpUtility.UrlEncode(movieName, Encoding.UTF8);
            string openApiUri = $"https://api.themoviedb.org/3/search/movie?api_key={tmdb_apiKey}" +
                                $"&language=ko-KR&page=1&include_adult=false&query={encoding_movieName}";
            // Debug.WriteLine(openApiUri);

            string result = string.Empty; // 결과값 

            // openapi 실행 객체
            WebRequest req = null;
            WebResponse res = null;
            StreamReader reader = null;

            try
            {
                // tmdb api 요청
                req = WebRequest.Create(openApiUri); // URL을 넣어서 객체를 생성
                res = await req.GetResponseAsync(); // 요청한 URL의 결과를 비동기응답
                reader = new StreamReader(res.GetResponseStream()); // 
                result = reader.ReadToEnd();  // json결과를 문자열로 저장

                Debug.WriteLine(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message}");
                // TODO : 메시지박스로 출력
            }
            finally
            {
                reader.Close();
                res.Close();
            }

            // result string을 Json으로 변경! 
            var jsonResult = JObject.Parse(result); // type.parse()는 ()안의 것으로 바꾸는 것 
            var total = Int32.Parse(jsonResult["total_results"].ToString());
            //await this.ShowMessageAsync("검색수",total.ToString());

            var results = jsonResult["results"];
            var jsonArray = results as JArray; // results가 Json 배열이기때문에 JArrays는 List와 동일 -> 따라서 foreach 사용가능 

            var movieItems = new List<MovieItem>();
            foreach(var item in jsonArray)
            {
                var movieItem = new MovieItem()
                {
                    // 프로퍼티라서 대문자로 시작, json 자체키가 adult 
                    // Convert.ToBoolean(object) == Boolean.Parse(string)
                    //  Convert.ToDouble() == Double.Parse(string) 
                    Adult = Boolean.Parse(item["adult"].ToString()),
                    Id = Int32.Parse(item["id"].ToString()),
                    Original_Language = item["original_language"].ToString(),
                    Original_Title = item["original_title"].ToString(),
                    Overview = item["overview"].ToString(),
                    Popularity = Double.Parse(item["popularity"].ToString()),
                    Poster_Path = item["poster_path"].ToString(),
                    Release_Date = item["release_date"].ToString(),
                    Title = item["title"].ToString(),
                    Vote_Average = Double.Parse(item["vote_average"].ToString()),
                    Vote_Count = Int32.Parse(item["vote_count"].ToString())
                };
                movieItems.Add(movieItem);
            }
            this.DataContext = movieItems;  
        }

        private void TxtMovieName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                BtnSearch_Click(sender, e); 
            }

        }


        private void GrdResult_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // 재검색하면 데이터 그리드 결과가 바뀌면서 이 이벤트가 다시 발생(예외처리) 
            try
            {
                var movie = GrdResult.SelectedItem as MovieItem;
                var poster_path = movie.Poster_Path;

                //await this.ShowMessageAsync("포스터", Poster_Path);
                if (string.IsNullOrEmpty(poster_path)) 
                {
                    ImgPoster.Source = new BitmapImage(new Uri("/No_Picture.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    var base_url = "https://image.tmdb.org/t/p/w300_and_h450_bestv2";
                    ImgPoster.Source = new BitmapImage(new Uri($"{base_url}{poster_path}", UriKind.Absolute));
                }

            }
            catch (Exception ex)  
            {
                Debug.WriteLine($"{ex.Message}");    
            }


        }

        private async void BtnAddFavorite_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("즐겨찾기", "즐겨찾기 추가합니다!");
        }

        private async void BtnViewFavorite_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("즐겨찾기", "즐겨찾기 확인합니다!!");
        }

        private async void BtnDelFavorite_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("즐겨찾기", "즐겨찾기 삭제합니다.");
        }

        private async void BtnWatchTrailer_Click(object sender, RoutedEventArgs e)
        {
            //await this.ShowMessageAsync("유튜브 예고편", "예고편 확인합니다");
            if(GrdResult.SelectedItems.Count == 0)
            { 
                await this.ShowMessageAsync("예고편 보기", "영화를 선택하세요");
                return; 
            }

            if (GrdResult.SelectedItems.Count > 1)
            {
                await this.ShowMessageAsync("예고편 보기", "영화를 하나만 선택하세요");
                return;
            }
            var TrailerWindow = new TrailerWindow();
            TrailerWindow.Owner = this;
            TrailerWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            TrailerWindow.ShowDialog();
        }
    }
}