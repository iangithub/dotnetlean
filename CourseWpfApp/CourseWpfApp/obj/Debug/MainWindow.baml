   M S B A M L   `   `   `  ????G  CCourseWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CourseWpfAppCourseWpfApp  5   	       CourseWpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CourseWpfApp     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??2* ?6   6,   ?? 5      $??1* ?6   6,   .+?5   
   ?? $??Stretch=?6   $??Stretch=?63   $??0??6O   ??5      ?? 5       ?? ImageSource$ Images/bg1.jpg??6    j? 
AlignmentY$ Center=?6:    j? 
AlignmentX$ Center=?6N    j? Stretch$ Uniform=?6b    ?? 	Transform 5      ?? 5       ?? ScaleX$ 1Q?6)    ?? ScaleY$ 1Q?64   5      5      ?? 5   
   $??20q?6   $??1??6!   $??Center=?61   .+?5      ?? $??Username??6   
???   ?6'   ?? 5      -   5        	 ??Name$	 Username??5      
???????
???   ?$??18(?6N   ?? 5      $??Password??6   
???   ?6'   G? 5      -   5        
 G?Name$
 Password??5      
???????
???   ?$??18(?6R   ?? 5      -   5         ??Name$ LoginBtn??5      $??10q?6'   $??25??63   $	??200??6?   ???#84C1FF$??Login??6`   
???????6?   5      5      5      