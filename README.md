# WeatherApp

### Popis aplikace

Tato aplikace slouží k získávání a zobrazení aktuálních údajů o počasí. Stahuje data z externího zdroje ve formátu XML, ukládá je do databáze a následně je zobrazuje na webové stránce.

### Postup spuštění

Pro lokální spuštění aplikace budete potřebovat:
* **Visual Studio** (s nainstalovanou podporou pro .NET 8.0)
* **SQL Server** nebo jiný kompatibilní databázový server.

Před spuštěním je nutné v souboru `appsettings.json` nastavit správný připojovací řetězec k vaší databázi.  Po spuštění aplikace automaticky stáhne data o počasí a uloží je do databáze.

### Nasazení

Tato aplikace je nasazena na hostingu MonsterASP.NET a je dostupná na adrese:
[https://weatherapp25.runasp.net/](https://weatherapp25.runasp.net/)

### Časová náročnost

Implementace této aplikace mi zabrala přibližně 5 hodin.
