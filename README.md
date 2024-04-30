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
        -
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
        - ColumnSpan : 열 넘어서까지 사용 하고자 하면 사용 
        
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
- WPF 기본 학습 
    - 데이터 바인딩 마무리 
    - 디자인 리소스
- WPF MVVM 


## 4일차 

## 5일차 

## 6일차 

## 7일차 

## 8일차 

## 9일차 