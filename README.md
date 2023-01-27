# Projekt zaliczeniowy z ASP.NET

Aplikacja realizuje funkcje kupna biletów na rózne wydarzenia.

Link do repozytorium: https://github.com/Voidde/ASP.NET---Projekt-Zaliczeniowy

# Opis funkcji: 

<h2>Niezalogowany użytkownik ma dostęp do</h2>

>Przeglądania listy wszystkich nadchodzących wydarzeń (Dostęp pod linkiem: <host_url>/Home/Index )
<img src = https://i.imgur.com/gE4l5fc.png />

>Przeglądania szczególów wydarzeń (Dostęp pod linkiem: <host_url>/Event/DetailsUser/{eventId}
<img src = https://i.imgur.com/gULTGa2.png />

>Oraz rejestracji zalogowania sie 

<h2>Zalogowany użytkownik ma dostęp do</h2>

>Wszystkich możliwych interakcji uzytkownika niezalogowanego

>"Zakupu" biletu na wydarzenie (Dostęp pod linkiem: <host_url>/Ticket/Create )
<img src = https://i.imgur.com/ylqIK0r.png />
Gdzie wpisuje swój email, Id eventu którego interesuje oraz cenę biletu <spoiler>(Niestety, ale nie potrafiłem przesłać danych pomiędzy widokami, bo ogólny zamysł był, aby tylko użytkownik musial wpisywać email, a reszta była by automatycznie wstrzykiwana z innego widoku)</spoiler>

Po wpisaniu poprawnych danych i kliknięciu przycisku "Create" zostanie utworzony nowy bilet na wydarzenie.
Przykładowe dane:
<img src = https://i.imgur.com/OCklg7W.png />

>Przeglądanie wszystkich swoich biletów (Dostępne pod linkiem: <host_url>/Ticket )
<img src = https://i.imgur.com/r6YAXcA.png />

Gdzie również pojawił się przykładowo utworzony wcześniej bilet.

>Przeglądania szczegółów swoich biletów (Dostęp pod linkiem: <host_url>/Ticket/Details/{ticketId}
<img src = https://i.imgur.com/tejbv7p.png />

<h2>Zalogowany użytkownik posiadający uprawnienia administratora ma dostęp do</h2>

>Wszystkich możliwych interakcji użytkownika zalogowane bez uprawień administratora

>Strony do zarządzania (Dodawanie,Usuwanie,Edytowanie,Przeglądanie) artystów (Dostęp pod linkiem: <host_url>/Artist )
<img src = https://i.imgur.com/w4oWqY9.png />

>Strony do zarządzania (Dodawanie,Usuwanie,Edytowanie,Przeglądanie) wydarzeniami (Dostęp pod linkiem: <host_url>/Event )
<img src = https://i.imgur.com/9eDFp6b.png />

>Strony do zarządzania (Dodawanie,Usuwanie,Edytowanie,Przeglądanie) miejscami, gdzie odbywają sie wydarzenia (Dostęp pod linkiem: <host_url>/Place )
<img src = https://i.imgur.com/hmEaC0Y.png />

>Strony do zarządzania (Dodawanie,Usuwanie,Edytowanie,Przeglądanie) wszystkich dostępnych biletów w systemie (Dostęp pod linkiem: <host_url>/Ticket )
<imsg src = https://i.imgur.com/XbyH7mc.png />

# Opis Instalacji:

Przy pierwszym uruchomieniu aplikacji należy zmienić łańcuch połączenia z bazą, po czym wykonać migrację i zupdateowac bazę danych.

>Łańcuch połączenia z bazą danych

W pliku <b>appsetings.json</b> należy zmienić następujący kod tak, aby utworzyło nam się połączenie z serwerem bazodanowym oraz bazą danych
```
  "AllowedHosts": "*",
  "Data": {
    "Connection": "DATA SOURCE=DatabaseServerConnection;Integrated Security=true;DATABASE=YourDatabase;Trust Server Certificate=true"
  }
```

"DATA SOURCE" możemy uzyskać np. z MSSQL (Microsoft SQL Server Management Studio). Przy uruchomieniu programu wyświetla się następujące okno

<img src = https://i.imgur.com/2DFxzWj.png />

I naszym "DATA SOURCE" jest to, co znajduje się w "Server Name:"

<img src = https://i.imgur.com/S1MG4RF.png />

W moim przypadku jest to: DESKTOP-Q4TE75C

"DATABASE" to nazwa bazy danych, której będziemy używac.Nazwa może być dowolna, tylko ważne, żeby nie było jeszcze takiej bazy.

Więc zmieniając ten kod w moim przypadku powinno być to:
```
  "AllowedHosts": "*",
  "Data": {
    "Connection": "DATA SOURCE=DESKTOP-Q4TE75C;Integrated Security=true;DATABASE=TicketService;Trust Server Certificate=true"
  }
```

>Migracja i aktualizacja bazy
Należy kliknąć PPM na "Projekt" po czym znaleźć "Otwórz w terminalu" i kliknąć na to LPM.
<img src = https://i.imgur.com/lGacPPb.png />

Otworzy się konsola PowerShell i musimy w niej wpisać następujące komendę
```
dotnet ef migrations add InitialCreate
```

Po czym jak utworzy nam się migracja, należy wpisać kolejną komendę
```
dotnet ef database update
```

>Dane logowania znajdujące się w bazie:

Zwykły użytkownik:
```
Email: TestUser@mail.com
Password: User.123
```
Administrator:
```
Email: Admin@mail.com
Password: User.155
```


