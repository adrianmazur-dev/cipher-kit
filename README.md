# Cipher-Kit

## Opis

Cipher-Kit to aplikacja służąca do szyfrowania i deszyfrowania tekstu za pomocą różnych algorytmów.

## Struktura Projektu

```
cipher-kit/
├── docs/                     # Dokumentacja projektu
│   ├── docs.md               
│   └── pdf                  
├── .gitignore                
├── README.md                 
└── src/                      # Kod źródłowy aplikacji
    ├── CipherKit.sln         # Solucja
    ├── CipherKit.App/        # Projekt Blazor WASM
    └── CipherKit.Core/       # Projekt biblioteki DLL

```

## Funkcje

Aplikacja oferuje następujące funkcje:

*   Szyfrowanie tekstu różnymi algorytmami (Cezar, Vigenère, RSA, Polibiusz, Playfair).
*   Deszyfrowanie zaszyfrowanego tekstu.
*   Intuicyjny interfejs użytkownika.
*   Możliwość kopiowania wyniku szyfrowania/deszyfrowania.

## Użycie

1.  Sklonuj repozytorium.
2.  Otwórz `CipherKit.sln` w Visual Studio.
3.  Uruchom projekt `CipherKit.App`.

## Dokumentacja

Szczegółowa dokumentacja aplikacji znajduje się w pliku [docs/docs.md](docs/docs.md).
