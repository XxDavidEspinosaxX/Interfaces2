   M S B A M L   `   `   `  ����@  <cine3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:cine3cine3  5   	       
cine3.Gui3   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:cine3     5   	     � Title$
  Gui3��5   	   $	��600��6   $
��1000��6#   .��5	      � -   5         �Name$
 grid��5	       � RowDefinitions 5
   
   �� 5      $
��103* �6   �� 5      $
��189* �6   .+�5   
   �� -   5         ��Name$ titulo��5      $��Gestor de Pel·lícules��6    $��Center=�6@   $��0,10,0,0q�6]   $	��Top=�6o   $��20(�6�   �� 5   
   $��Consulta de Pel·lícules��6   $��Center=�62   $	��Top=�6O   $��16(�6g   $��	0,109,0,0q�6u   �� 5   
   -   5         ��Name$ listBoxPeliculas��5      $
��Left=�6,   $��	9,139,0,0q�6G   $	��Top=�6Z   $	��950��6r   $	��200��6~   $��2��6�   �� 5   
   $��Filtrar per Gènere��6   $
��Left=�6-   $��	9,153,0,0q�6H   $	��Top=�6[   $��1��6s   �� 5   
   -   5         ��Name$ cb_filtrarGenere��5      $
��Left=�6-   $��119,153,0,0q�6H   $	��Top=�6]   $	��150��6u   $��1��6�   ��6�   ��  �� Path$ 
GenereList�6�   �� 5   
   $��Filtrar per Data��6   $
��Left=�6+   $��299,153,0,0q�6F   $	��Top=�6[   $��1��6s   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dp_filtrarData��5      $
��Left=�6-   $��409,153,0,0q�6H   $	��Top=�6]   $��1��6�   �� 5   
   $��Filtrar per Idioma��6   $
��Left=�6-   $��599,153,0,0q�6H   $	��Top=�6]   $��1��6u   �� 5    
   -   5        $ cb_filtrarIdioma��5       $
��Left=�6-   $��709,153,0,0q�6H   $	��Top=�6]   $	��150��6u   $��1��6�   ��6�   �� $ LanguageList�6�   �� 5#   
   -   5         ��Name$ bt_mostrarTot��5#      $��Mostrar Tot��6(   $
��Left=�6>   $	��Top=�6Y   $��417,261,0,0q�6q   $	��150��6�   $��1��6�   �� 5$   
   -   5        $ 
bt_iragui5��5$      $��Seleccionar butaca��6%   $
��Left=�6B   $��431,306,0,0q�6]   $��1��6r   $	��Top=�6   $��20��6�   $	��122��6�   6�   5%      5&      