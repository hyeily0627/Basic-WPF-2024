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
        - 윈폼과는 다르게 코딩으로 디자인! 
        - 이름 설정 : x:Name="" 
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

## 2일차 

## 3일차 

## 4일차 

## 5일차 

## 6일차 

## 7일차 

## 8일차 

## 9일차 