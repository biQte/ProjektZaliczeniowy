# ProjektZaliczeniowy

## Opis projektu

**ProjektZaliczeniowy** to aplikacja webowa stworzona w technologii ASP.NET MVC, służąca do zarządzania magazynem. Umożliwia dodawanie i edycję produktów, zarządzanie przyjęciami zewnętrznymi oraz obsługę użytkowników z różnymi poziomami uprawnień.

---

## Wymagania

- **System operacyjny**: Windows 10 lub nowszy
- **Środowisko programistyczne**: Visual Studio 2019 lub nowszy
- **Framework**: .NET Core 3.1 lub nowszy
- **Baza danych**: SQL Server

---

## Instalacja

### 1. Klonowanie repozytorium

Sklonuj repozytorium na swój lokalny komputer:

```bash
git clone https://github.com/biQte/ProjektZaliczeniowy.git
```

### 2. Przywrócenie pakietów NuGet

Otwórz rozwiązanie w Visual Studio i w **Konsoli Menedżera Pakietów** uruchom:

```powershell
dotnet restore
```

### 3. Konfiguracja bazy danych

- Upewnij się, że SQL Server jest uruchomiony.
- W pliku `appsettings.json` skonfiguruj łańcuch połączenia z bazą danych:

  ```json
  "ConnectionStrings": {
    "WarehouseManagement": "Server=YOUR_SERVER_NAME;Database=ProjektZaliczeniowy;Trusted_Connection=True;TrustServerCertificate=True"
  }
  ```

- W **Konsoli Menedżera Pakietów** uruchom migracje, aby utworzyć bazę danych:

  ```powershell
  Update-Database
  ```

### 4. Uruchomienie aplikacji

Po pomyślnym skonfigurowaniu bazy danych uruchom aplikację w Visual Studio, wybierając odpowiedni profil uruchomieniowy.

---

## Konfiguracja

### Łańcuch połączenia z bazą danych

Łańcuch połączenia znajduje się w pliku `appsettings.json` w sekcji `ConnectionStrings`. Należy zastąpić `YOUR_SERVER_NAME` nazwą swojego serwera SQL.

### Testowi użytkownicy

Przy pierwszym uruchomieniu aplikacji tworzone jest domyślne konto administratora. Dane logowania są wyświetlane na stronie głównej i należy je zapisać, ponieważ nie będą ponownie dostępne. Po zalogowaniu jako administrator można dodawać nowych użytkowników z różnymi rolami.

---

## Opis działania aplikacji

### Strona główna

Po uruchomieniu aplikacji jeśli nie istnieje żadne konto jest ono tworzone i wyświetlane. Jeśli konto już istnieje wyświetlana jest informacja o gotowości do działania oraz przycisk przekierowywujący do ekranu logowania. Po zalogowaniu dostępne są następujące funkcje:

### Zarządzanie produktami

- **Dodawanie produktu**: Umożliwia wprowadzenie nowego produktu do magazynu, podając nazwę, EAN, numer katalogowy oraz lokalizację w magazynie.
- **Edycja produktu**: Pozwala na modyfikację nazwy oraz lokalizacji wybranego produktu.
- **Usuwanie produktu**: Pozwala na usunięcie produktu z bazy danych.
- **Wyświetlanie produktów**: Wyświetla użytkownikowi listę produktów z wszyskimi kluczowymi informacjami.

### Przyjęcia zewnętrzne

- **Lista przyjęć**: Wyświetla wszystkie przyjęcia zewnętrzne z informacjami o numerze przyjęcia, liczbie produktów, dacie przyjęcia oraz osobie wprowadzającej.
- **Szczegóły przyjęcia**: Po wybraniu konkretnego przyjęcia można zobaczyć listę produktów z ich ilościami oraz uwagi.
- **Nowe przyjęcie**: Umożliwia dodanie nowego przyjęcia, wybierając produkty z listy, podając ich ilości oraz wpisując uwagi.

### Przyjęcia wewnętrzne
- **Lista przyjęc**: Wyświetla wszystkie pryzjęcia wewnętrzne (inaczej nazywane kompletacją produktów) z informacjami o numerze przyjęcia, liczbie produktów, dacie przyjęcia oraz osobie wprowadzającej.
- **Szczegóły przyjęcia**: Po wybraniu konkretnego przyjęcia można zobaczyć listę produktów z ich ilościami oraz uwagi.
- **Nowe przyjęcie**: Umożliwia dodanie nowego przyjęcia, wybierając produkty z listy, podając ich ilości oraz wpisując uwagi

### Wydania zewnętrzne
- **Lista wydań**: Wyświetla wszystkie wydania zewnętrzne z informacjami o numerze wydania, liczbie produktów, dacie wydania oraz osobie wprowadzającej.
- **Szczegóły wydania**: Po wybraniu konkretnego wydania można zobaczyć listę produktów z ich ilościami oraz uwagi.
- **Nowe wydanie**: Umożliwia dodanie nowego wydania, wybierając produkty z listy, podając ich ilości oraz wpisując uwagi

### Rozchody wewnętrzne
- **Lista rozchodów**: Wyświetla wszystkie rozchody wewnętrzne (opuszczanie produktu z magazynu nie związane ze sprzedażą, np. utylizacja wadliwego produktu) z informacjami o numerze rozchodu, liczbie produktów, dacie wydania oraz osobie wprowadzającej.
- **Szczegóły rozchodu**: Po wybraniu konkretnego rozchodu można zobaczyć listę produktów z ich ilościami oraz uwagi.
- **Nowy rozchód**: Umożliwia dodanie nowego rozchodu, wybierając produkty z listy, podając ich ilości oraz wpisując uwagi

### Zarządzanie użytkownikami (tylko dla administratora)

- **Dodawanie użytkownika**: Administrator może dodawać nowych użytkowników, przypisując im odpowiednie role.
- **Lista użytkowników**: Wyświetla wszystkich użytkowników systemu z informacjami o ich rolach.

### Informacje powiązane
- **Zarządzanie stanami magazynowymi produktów**: Wszystkie zmiany stanu magazynowego produkt są wprowadzane za pomocą dokumentów, nie da się zmodyfikować ilości w edycji produktu, pozwala to na dokładniejsze zarządzanie magazynem.
- **Osoba wprowadzająca**: Automatycznie przypisywana jest do dokumentu na podstawie zalogowanej osoby wprowadzającej dokument.

---

## Uwagi

- Przed pierwszym uruchomieniem upewnij się, że wszystkie migracje zostały zastosowane i baza danych jest poprawnie skonfigurowana.
- W przypadku problemów z logowaniem lub innymi funkcjami aplikacji sprawdź konfigurację łańcucha połączenia oraz upewnij się, że SQL Server jest uruchomiony.
