# Projekt zaliczeniowy - Aplikacja do zarządzania magazynem w ASP.NET MVC

> [!NOTE]
> Aplikacja do działania wymaga zainstalowanego Visual Studio oraz SQL Server Management Studio

## Aby uruchomić projekt należy

1. Sklonować to repozytorium
```bash
git clone https://github.com/biQte/ProjektZaliczeniowy
```
2. W sekcji Package Manager Console wpisać komendy
```bash
dotnet restore
```

3. Utworzyć bazę danych z istniejącej już migracji
```bash
Update-Database
```

4. Uruchomić projekt

5. Przy pierwszym uruchomieniu aplikacji zostaje utworzone domyślne konto administratora, należy zapisać wyświetlone dane gdyż nie zostanę one wyświelone już ponownie

6. Po odświeżeniu strony można zalogować się do systemu za pomocą domyślnych poświadczeń

7. Będac zalogowanym można zarządzać magazynem, jeśli zalogowany użytkownik jest adminem może on dodatkowo zarządzać użytkownikami
