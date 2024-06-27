# Intercom CRM
Настольное приложение, созданное в качестве учебного проекта. Оно представляет собой CRM систему для ускорения и автоматизации работы домофонной компании. 
  
В приложении есть 4 вкладки: Заявки, Адреса, Сотрудники, Домофоны. Во вкладках заявки и адреса реализованы CRUD операции (создание, чтение, редактирование, удаление), во вкладках сотрудники и домофоны - только чтение. Кроме того, предусматривается специальные механизмы обработки исключений и ошибок, чтобы работа программа не завершалась аварийно. 

# Инструменты и технологии
Разработка происходила на Windows Forms, с использованием языка программирования C#. В качестве СУБД использовалось MySQL Workbench.  

В рамках проекта был произведен анализ рынка приложений со схожим функционалом. Была составлена таблица сравнения аналогов, благодаря которой можно было ознакомиться с их
сильными и слабыми сторонами. Полученные данные использовались при разработке концепции приложения.  

Проектирование базы данных включало в себя несколько этапов. Концептуальное проектирование, даталогическое проектирование и физическое проектирование. 
Также была проведена нормализацию до третьей нормальной формы. При проектировании базы данных была простроена ERR-диаграмма Чена, а впоследствии и полноценная схема базы данных.
