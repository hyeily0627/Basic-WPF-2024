# Basic-WPF-2024
# WPF 윈폼 개발 학습 
부경대학교 2024 IoT 개발자 과정 - WPF 학습 리포지토리


## 1일차(2024-04-29) 
- C# / Windows / 데스크톱 : WPF 애플리케이션 or WPF앱(.NET Framework)

- WPF 기본학습
    - Winforms 확장한 WPF(Windows Presentation Foundation)
        - 이전 Winforms는 이미지가 비트맵 방식
        - WPF는 이미지가 벡터 방식 
        - XAML(eXtensible Application Markup Language)을 사용한 화면 디자인 
        
    - XAML(엑스에이엠엘, 재믈로 읽음)
        - 여는 태그<Wimdow>, 닫는 태그</Window> 
        - 합치면 <Window /> : Windowm 태그 안에 다른 객체가 없다는 뜻
        - 여는 태그와 닫는 태그사이에 다른 태그(객체)를 넣어서 디자인 
        - 주석 <!-- 블라블라 -->
            - ctrl + k + c 
            - 해제 ctrl + k + u

    - WPF 기본 사용법
        - 윈폼과는 다르게 코딩으로 디자인
        - 이름 설정 : x:Name="" 
        - 바깥 라인에 마우스 올렸을때 마우스 모양 흰색과 + 모양이 있는 마우스로 바뀐 후 클릭시 그리드 행 추가 됨.
        - 배율 설정(*) 
        <Grid.RowDefinitions>
            <RowDefinition Height="1*"/>
            <RowDefinition Height="1*"/>
            <RowDefinition Height="1*"/>
            <RowDefinition Height="1*"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="1*"/>
            <ColumnDefinition Width="1*"/>
            <ColumnDefinition Width="1*"/>
        </Grid.ColumnDefinitions>
        ![비율](https://github.com/hyeily0627/Basic-WPF-2024/assets/156732476/27cb96bc-f217-4ce0-b0dd-a65890d3edb7)
 
        100단위 넘어가면 사이즈이고, 그 값을 제외한 비율로 설정 
        - ColumnSpan : 열 넘어서까지(옆 열까지 전부) 사용 하고자 하면 사용 
        
    - 디자인 코딩방법
        - 레이아웃
            1. Canvas : 미술에서 캔버스와 유사
            2. StackPanel : 스택으로 컨트롤을 쌓는 레이아웃
            3. DockPanel : 컨트롤을 방향에 따라서 도킹 시키는 레이아웃
            4. Grid : WPF에서 가장 많이 사용하는 대표적인 레이아웃 
            5. 🚨Mergin - 여백기능, 앵커링 같이함! 
                -  Margin 
                <!--Margin left, top, right, botton 순으로 여백이 만들어짐 -->
                Margin="20" : 위아래양옆 모두 20
                Margin="10, 20" :  양옆 10, 위아래 20 
                Margin="10, 20, 30, 40" : 왼 10, 위 20, 오 30, 아래 40 
    - 디자인, C# 코드 완전분리 개발 -> MVVM 디자인 패턴

#region
#endregion

## 2일차 (2024-04-30)  
(Iot System Developer 02 INTERMEDIATE 02. WPF AB.WPF기본 51P 
https://youneedawiki.com/app/page/1LPc20daicuGYTji9Me9M15JJnA8qvgeg)
- WPF 기본 학습 
    - 어떠한 이벤트 없이 데이터를 전달하여 사용하는 것  : 데이터 바인딩 
    - 데이터 소스(DB, 엑셀, txt, 클라우드에 보관된 데이터 원본)에 데이터를 쉽게 가져다 쓰기위해 사용
        - Xaml 사용 문법 : {Binding Path=속성, ElementName:객체, Mode=(oneWay|TwoWay), StringFormat={}{0:#.#}}
        - DataContext : 데이터를 담아서 전달하는 이름
        - 전통적인 윈폼 코드 비하인드에서 데이터를 처리하는 것을 '지양'하기 위해 사용 : 디자인과 개발을 분리! 

## 3일차 
- WPF에서 중요한 개념(윈폼과 다른점)
    1. 데이터 바인딩 : 바인딩 키워드로 코드와 분리! 
    2. 옵저버 패턴 : 값이 변경된 사실을 사용자에게 공지 
    3. 디자인 리소스 : 각 컨트롤마다 디자인 X, 리소스로 디자인을 공유함 

- WPF 기본 학습 
    - 데이터 바인딩 마무리 
        - <local>의 경우 라벨 안에 사용해야함
        - Text="{Binding Speed}"/> 으로 쓰거나 Text="{Binding Path=Speed}"/> 써도 무방함
    - 디자인 리소스 - 각 컨트롤마다 디자인(X), 리소스로 디자인 공유 
        - 각 화면당 Resources : 자기 화면에만 적용되는 디자인   
        - App.xaml Resources : 애플리케이션 전체에 적용되는 디자인
        - 리소스사전 : 공유할 디자인 내용이 많을 때 파일로 따로 지정
        
- WPF MVVM 
    - MVC(Model View Controller 패턴)
        - 웹개발(Spring, ASP.NET MVC, dJango, etc...) 에 현재도 사용되고 있음
        - Model : DATA 입출력 처리를 담당
        - View : 디스플레이 화면 담당
        - Controller : View를 제어, Model 처리 중앙에 관장 

    - MVVM (Model View ViewModel)
        - Model : DATA 입출력(DB쪽으로)
        - View : 화면, 순수 xmal로만 구성 
        - ViewModel : 뷰에 대한 메서드, 액션, INotifyPropertyChanged를 구현 

    ![Mvvm패턴](https://raw.githubusercontent.com/hyeily0627/Basic-WPF-2024/main/images/wpf001.png)

    - 권장 구현방법
        - ViewModel 생성, 알림 속성 구현
        - View에 ViewMode를 데이터 바인딩
        - Model DB작업 독립적으로 구현
        
    - MVVM 구현 도와주는 프레임워크
        0. ~~Mvvmlight.Toolkit~~ - 3rd Party 개발. 더이상 개발이나 지원이 없음. 2009년부터 시작 2014년도 이후 더이상 개발이나 지원이 없음
        1. **Caliburn.Micro** - 3rd Party 개발. MVVM이 아주 간단. 강력. 디버깅이 조금 어려움, 중소형 프로젝트에 적합
        2. AvaloniaUI - 3rd Party 개발. 크로스플랫폼. 디자인은 최고
        3. Prism - Microsoft 개발. 무지막지하게 어렵다. 대규모 프로젝트에 활용

- Calibrun.Micro
    1. 프로젝트 생성 후 MainWindow.Xaml 삭제
    2. Models, Views, ViewModels 폴더(네임스페이스) 생성 
    3. 종속성에서 Nuget패키지 Calibrun.Micro 설치 
    4. 루트 폴더에 Bootstrapper.cs 클래스 생성, 작성 
    ```C
    public class Bootstrapper : BootstrapperBase // Alt Enter 해서 네임스페이스 추가 (using Caliburn.Micro;)
    {
        public Bootstrapper()
        {
            Initialize(); // Caliburn.Micro MVVM 시작하도록 초기화 
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e); //나중에 주석처리
        }
    }
    ```
    5. App.xaml에서 StartupUri 삭제 
    6. App.xaml에서 Bootstrapper 클래스를 리소스 사전에 등록 
        - xaml 상의 파란색 밑줄은 대부분 빌드(F6)으로 사라짐! 
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary>
                        <local:Bootstrapper x:Key="bootstrapper"/>
                    </ResourceDictionary>
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>  
        </Application.Resources>
    7. App.xaml.cs에 App() 생성자 추가 
    8. viewModels 폴더에 MainViewModel 클래스 생성 
    9. Bootstrapper.cs Onstartup()에 내용을 변경 
    10. Views 폴더에 MainView.xaml 생성

    - 작업(3명 분리)
        - DB개발자 - DBMS 테이블 생성, Models에 클래스 작업
        - Xaml디자이너 - Views 폴더에 있는 xaml 파일을 디자인작업

## 4일차 (2024-05-03)
- Caliburn.Micro   
    - 작업분리 
        - Xaml디자이너 :  Xaml 파일만 디자인 
        - ViewModel개발자 : Model에 있는 DB관련 정보와 View와 연계 전체구현 작업 

        - Microsoft.Data.SqlClient 다운 (Nuget)

    - Caliburn.Micro 특징
        - Xaml 디자인시 {Binding...}은 잘 사용하지 않음
        - 대신 x : Name을 사용 
        ![xname](https://raw.githubusercontent.com/hyeily0627/Basic-WPF-2024/main/images/a.png)

    - MVVM 특징 
        - 예외발생시 예외메시지 표시 없이 프로그램 종료 
        - **F5를 눌러 디버깅**하여 오류 확인! 
        - ViewModel에서 디버깅 시작 

## 5일차 

## 6일차 

## 7일차 

## 8일차 

## 9일차 
