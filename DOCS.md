# Dokumentacja Aplikacji Cipher-Kit

## Wprowadzenie

Aplikacja Cipher-Kit to narzędzie do szyfrowania i deszyfrowania tekstu przy użyciu różnych algorytmów szyfrowania. Aplikacja umożliwia użytkownikom zabezpieczanie wiadomości poprzez ich kodowanie oraz odkodowywanie wiadomości zakodowanych przez inne osoby.

## Dostępne Szyfry

Aplikacja oferuje następujące algorytmy szyfrowania:

1.  **Szyfr Cezara:** Prosty szyfr podstawieniowy, w którym każda litera tekstu jawnego jest zastępowana literą przesuniętą o stałą liczbę pozycji w alfabecie.
2.  **Szyfr Vigenère'a:** Szyfr polialfabetyczny, który używa słowa kluczowego do określenia przesunięcia dla każdej litery tekstu jawnego.
3.  **Szyfr RSA:** Asymetryczny algorytm kryptograficzny, szeroko stosowany w systemach bezpiecznej komunikacji i uwierzytelniania.
4.  **Szyfr Polibiusza:** Szyfr podstawieniowy, w którym każda litera jest zastępowana przez parę cyfr, wskazujących na jej pozycję w tablicy Polibiusza.
5.  **Szyfr Playfair'a:** Szyfr digrafowy, który szyfruje pary liter zamiast pojedynczych liter.

## Interfejs Użytkownika

### Główne Elementy

*   **Pole Tekst Jawny:** Obszar tekstowy, w którym użytkownik wprowadza tekst do zaszyfrowania.
*   **Pole Tekst Zaszyfrowany:** Obszar tekstowy, w którym wyświetlany jest zaszyfrowany lub odszyfrowany tekst.
*   **Wybór Szyfru:** Lista rozwijana umożliwiająca wybór algorytmu szyfrowania.
*   **Pole Klucza:** Pole tekstowe, w którym użytkownik wprowadza klucz wymagany przez niektóre algorytmy szyfrowania (np. Szyfr Vigenère'a).
*   **Przycisk Szyfruj:** Przycisk uruchamiający proces szyfrowania tekstu jawnego.
*   **Przycisk Deszyfruj:** Przycisk uruchamiający proces deszyfrowania tekstu zaszyfrowanego.
*   **Przycisk Kopiuj** Kliknięcie przycisku "Kopiuj" powoduje wprowadzenie tekstu wynikowego do wejściowego 

### Funkcje

1.  **Szyfrowanie:**
    *   Użytkownik wprowadza tekst jawny do odpowiedniego pola.
    *   Wybiera algorytm szyfrowania z listy rozwijanej.
    *   Wprowadza klucz, jeśli jest wymagany przez wybrany algorytm.
    *   Kliknięcie przycisku "Szyfruj" powoduje zaszyfrowanie tekstu i wyświetlenie wyniku w polu "Tekst Zaszyfrowany".
2.  **Deszyfrowanie:**
    *   Użytkownik wprowadza tekst zaszyfrowany do odpowiedniego pola.
    *   Wybiera algorytm szyfrowania, który został użyty do zaszyfrowania tekstu.
    *   Wprowadza klucz, jeśli był używany podczas szyfrowania.
    *   Kliknięcie przycisku "Deszyfruj" powoduje odszyfrowanie tekstu i wyświetlenie wyniku w polu "Tekst Jawny".
3. **Kopiowanie wyniku**
    *   Kliknięcie przycisku "Kopiuj" powoduje wprowadzenie tekstu wynikowego do wejściowego

## Użycie Aplikacji

1.  Uruchom aplikację Cipher-Kit.
2.  Wybierz żądany algorytm szyfrowania z listy dostępnych szyfrów.
3.  Wprowadź tekst do zaszyfrowania lub odszyfrowania w odpowiednim polu tekstowym.
4.  Wprowadź klucz, jeśli jest wymagany przez wybrany algorytm.
5.  Kliknij przycisk "Szyfruj" lub "Deszyfruj", aby wykonać odpowiednią operację.
6.  Wynik zostanie wyświetlony w odpowiednim polu tekstowym.
