using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniproject.Models
{
    public class Attraction
    {
        public int Id { get; set; } // 추가생성, DB에 넣을때 사용할 값
        public string MAIN_TITLE { get; set; } // 콘텐츠명
        public string GUGUN_NM { get; set; } // 구,군 이름
        public double LAT { get; set; } // 위도
        public double LNG { get; set; } // 경도
        public string PLACE { get; set; } // 여행지
        public string TITLE { get; set; } // 제목
        public string SUBTITLE { get; set; } // 부제목
        public string ADDR1 { get; set; } // 주소
        public int CNTCT_TEL { get; set; } // 연락처
        public string HOMEPAGE_URL { get; set; } // 홈페이지 
        public string TRFC_INFO { get; set; } // 교통정보

        public static readonly string INSERT_QUERY = @"";

        public static readonly string SELECT_QUERY = @"";

        public static readonly string GETDATE_QUERY = @"";
    }
}
}
