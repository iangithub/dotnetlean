   M S B A M L   `   `   `  ????G  CCourseWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CourseWpfAppCourseWpfApp  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   *    $CourseWpfApp.CourseScheduleFunCreate   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CourseWpfApp     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     ? Title$  CourseScheduleFunCreate??5	   	   $	??450??6)   $	??800??66    ? 	Resources 5
       ?? 
TargetType ?? Property ?? Value??%?   '??       '?? N     ?? 5   
   " ??6   .?5      ??  ? ??$	 300??6&   64   5      ?? 5   
   " ??6   .?5      ??  ? ??$	 120??6&   64   ?? 5       ? ??$ 14(?6)   66   5      5      .??5      ? .+?5   
   ?? $??1??6   $??10q?6"   ???#0ABAB5.+?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??5q?6   課程6+   ?? 5      -   5         ??Name$ CourseCombo??5       ?? DisplayMemberPath$
 Name??60    ?? SelectedValuePath$	 Cid??6I   	 ?? SelectedValue	 5      ?? 
 ?? Path$	
 Cid?6A   5      ?? 5      $ 
Horizontal=?6   .+?5      ?? $??5q?6   授課講師6.   ?? 5      -   5        $ TeacherCombo??5      $
 Name??61   $	 Tid??6J   	 5      ?? $	
 Tid?6@   5      ?? 5      $ 
Horizontal=?6   .+?5       ?? $??5q?6   課程日期6.   (  "System.Windows.Controls.DatePicker  5!         SelectedDate 6   ?? $
 Sdate?
 ?? Now ?? TargetNullValue# Z 6s   ?? 5"      $??1q?6   ~6-     5#       6   ?? $
 Edate?# Z 6s   5$      ?? 5%      $ 
Horizontal=?6   .+?5&      ?? $??5q?6   課程地點6.   ?? 5'      $??5q?6   ??6%   ?? $
 Location?6F   5(      ?? 5)      $ 
Horizontal=?6   .+?5*      ?? -   5         ??Name$ 	CreateBtn??5*      $??儲存??6,   $??10q?69   $
??Left=?6E   $	??Top=?6`   $??75??6x   6?   5+      5,      5-      5.      