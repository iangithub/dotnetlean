   M S B A M L   `   `   `  ????G  CCourseWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CourseWpfAppCourseWpfApp  5          CourseWpfApp.PwdFunPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CourseWpfApp     5        N? 
Background  ?#F1DB6C N? Title$ 
PwdFunPage??5
       ? 	Resources 5       ?? 
TargetType ?? Property ?? Value   StackPanelHorizontal??%D  '??       'G? N     &	  ?     ?? 5   
   " ??6   .?5      ??  ? ??$	 100??6&   64   5      ?? 5   
   " G?6   .?5      ??  ? ??$	 200??6&   64   5      ?? 5   
   " ??6   .?5      ??  ?@??Orientation$ 
Horizontal=?6,   6A   ?? 5       ? ??$ 10q?6'   64   5      5      .??5      ?? $??20q?6   .+?5   
   ?? #??[  6   .+?5      ?? $??原始密碼??6   6%   G? 5      -   5         G?Name$ OldPwd??5      6,   5      ?? 5   
   #??[  6   .+?5      ?? $??	新密碼??6   6$   G? 5       -   5        $ NewPwd??5       6,   5!      ?? 5"   
   #??[  6   .+?5#      ?? $??再次確認密碼??6   6'   G? 5$      -   5        $ 
ConfirmPwd??5$      60   5%      ?? 5&   
   -   5         ??Name$ 	PwdChgBtn??5&      .??6<   變更密碼6B   5'      5(      