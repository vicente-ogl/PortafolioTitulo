   M S B A M L   `   `   `  ????L  HControl de Tareas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Control_de_TareasControl_de_Tareas  5   	   "    Control_de_Tareas.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Control_de_Tareas     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     ? Title$+  %Process S.A Control de Tareas - Login??5   	   $	??450??67   $	??800??6D    ? 
ResizeMode$ NoResize=?6P    ? WindowStartupLocation$ CenterScreen=?6f      MaterialDesignBody#???   5
   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	   .??5      ? ???	#FF171725$??Center=?6"   $??Center=?6?   .+?5   
   ?? $??Center=?6   $	??434??61   $??Center=?6>   $	??800??6Y    J? Opacity$	 0.2Q?6e   ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&    ?? 
StartPoint$ 0.5,0&?67   .??5      ?  ? Color$ 	#FF18B9BD??6#   ? 5      $ 	#FF35C781??6#   	 ? Offset$	 1Q?65   5      5      ?? 5   
   -   5        
 ??Name$
 btn_connectBD??5      $&?? Probar Conexión a Base de datos??6D   
???????$
??Left=?6?   $??Bottom=?6?   ???	#FF11A8A8$??	15,0,0,15q?6?   6?   ?? 5   
   $??Center=?6   $	??180??61   $??	0,147,0,0q?6>   $	??Top=?6Q   $	??350??6i   ???	#FFEDEDED6u   ?? 5   
   $
??Left=?6   $??83??6+   $??	23,16,0,0q?67    ?? BitmapScalingMode$ HighQuality=?6J   $	??Top=?6x   $	??244??6?   $??/Process Color Alpha.png??6?   ?? 5   
   -   5        $
 btnLogin??5      $??Login??6#   $??Center=?6J   $??	0,281,0,0q?6g   $	??Top=?6z   $	??120??6?   ???	#FF11A8A8
?????????6?   Z? 6?   ?? 5   
   $
??Left=?6   $	??174??6+   $??
716,16,0,0q?68   $ HighQuality=?6L   $	??Top=?6z   $??48??6?   $??/Control de Tareas.png??6?   ?? 5   
   $??
Bienvenido??6   
???   ?$??Center=?68   $??25??6U   $??	0,147,0,0q?6a   $	??Top=?6t   $??71??6?   ?? 5    
   $??Ingrese sus datos??6   
???   ?$??Center=?6?   $??28??6\   $??	0,160,0,0q?6h   $	??Top=?6{   $	??120??6?   $??14(?6?   ? 5!   
   .+?5"      ?? -   5         ??Name$ 
txtBoxUser??5"      $?? ??6   
???   ?$
??Left=?6E    ?? TextWrapping$
 Wrap=?6`   $??Center=?6t   $	??200??6?   $??	366,0,0,0q?6?   G? 5#      -   5         G?Name$ txtBoxPassword??5#   9    G? Password$  ??6   
???   ?$
??Left=?6Q   $??366,240,0,0q?6l   $	??Top=?6?   $	??200??6?   ?? 5$      -   5         ??Name$ txtUser??5$      $??Correo Electrónico??6%   $
??Left=?6B   $??Center=?6]   $??	238,0,0,0q?6   $??Center=?6?   
???   ?$??34??6?   ??6?   Z? 6?   ?? 5%      -   5        $ txtPassword??5%      $??Contraseña??6)   $
??Left=?6>   $??Center=?6Y   $??257,235,0,0q?6{   $	??Top=?6?   
???   ?$??34??6?   ??6?   Z? 6?   5&      5(      5)      