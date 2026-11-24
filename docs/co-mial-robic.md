# Specyfikacja minutnika Pomodoro

## 1. Co robi

1. Program umożliwia odliczanie czasu pracy, domyślnie 25 minut.
2. Program umożliwia odliczanie czasu przerwy, domyślnie 5 minut.
3. Użytkownik może zmieniać długość pracy i przerwy w oknie aplikacji.
4. Program posiada jeden przycisk Start/Pauza oraz drugi przycisk Reset.
5. Program wyświetla liczbę ukończonych cykli.
6. Po zakończeniu czasu pracy program automatycznie rozpoczyna przerwę.
7. Pozostały czas jest wyświetlany w formacie mm:ss.
8. Interfejs aplikacji jest w języku polskim.
9. Program umożliwia przeglądanie historii ukończonych cykli.

## 2. Czego nie robi

- Nie zapisuje historii cykli po zamknięciu aplikacji.
- Nie synchronizuje danych z internetem.
- Nie wysyła powiadomień na telefon.
- Nie zarządza zadaniami ani listą obowiązków.
- Nie uruchamia automatycznie kolejnego cyklu pracy bez działania użytkownika.

## 3. Po czym poznam, że działa

1. Kiedy kliknę Start, minutnik rozpocznie odliczanie.
2. Kiedy kliknę Pauza, odliczanie zostanie zatrzymane.
3. Kiedy kliknę Wznów, odliczanie będzie kontynuowane.
4. Kiedy czas pracy dobiegnie końca, minutnik automatycznie przejdzie do przerwy.
5. Kiedy zakończy się pełny cykl, licznik ukończonych cykli zwiększy się o jeden.

## 4. Do ustalenia

- Czy historia cykli powinna być zapisywana po zamknięciu aplikacji?
- Czy aplikacja powinna automatycznie rozpoczynać kolejny cykl po przerwie?
- Czy powinny pojawiać się powiadomienia dźwiękowe po zakończeniu odliczania?

## 5. Zasady techniczne

- Nazwy klas, metod i zmiennych w kodzie są w języku angielskim.
- Program nie korzysta z żadnych dodatkowych bibliotek.