Реализованная функциональность

    Регистрация
    Авторизация
    Прием данных
    Отправка данных
    Обработка данных

Особенность проекта в следующем:

    Поддержка любой серверной ОС

Основной стек технологий:

    C# 
    Asp.net Web Api
    Entity Framework
    Git
    GitHub
    OpenApi


Среда запуска
    
    Любая ОС с поддержкой .net6.0 SDK
    
Как скомпилировать

    В случае использования nginx(или другого прокси) - настроить nginx, прослушиваемый приложением порт указан в файле https://github.com/SilentSt/SCP-682/blob/master/SCP%20682/Program.cs#L22
    В случае отсутствия прокси указать адрес сервера, на котором будет запущено приложение в файле https://github.com/SilentSt/SCP-682/blob/master/SCP%20682/Program.cs#L22
    Также упомянутый выше адрес и порт используются в мобильном приложении
    Установить .net6.0 SDK:
        wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
        sudo dpkg -i packages-microsoft-prod.deb
        rm packages-microsoft-prod.deb
        
        sudo apt-get update; \
        sudo apt-get install -y apt-transport-https && \
        sudo apt-get update && \
        sudo apt-get install -y dotnet-sdk-6.0
    Установить MySql:
        sudo apt install mysql-server
    Настроить MySql
    Ввести данные для подключения к MySql в файл https://github.com/SilentSt/SCP-682/blob/master/SCPContext/SCPContext.cs#L17
    Из папки решения(не проекта) выполнить сборку решения (dotnet build)
    Из папки проекта "SCP 682" выполнить запуск проекта (dotnet run)
    Готово

Разработчики

    Первушин Максим https://t.me/@whiskas44
    Светличная Карина https://t.me/@kflnch   
    Кириченко Кирилл https://t.me/@smartsem
