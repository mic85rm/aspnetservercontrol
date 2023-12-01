BWebTemplate v.1.0.8
--------------------

1. Aprite proprietà di progetto e cambia la sezione "web configuration" impostando iis locale e clicca su "create the folder" (consigliato)
2. Create un database applicativo Vuoto tramite SSMS.
3. Impostate le seguenti chiavi del web config:

    <!--IMPOSTAZIONE DI CONNESSIONE DB APPLICATION-->
    <add key="DBAPP_DB" value="{db name}" />
    <add key="DBAPP_SERVER" value="{server name}" />
    <add key="DBAPP_USER" value="{user id}" />
    <add key="DBAPP_PWD" value="{pwd criptata con BCrypter}" />

4. Prima di avviare l'applicazione assicuratevi che tutti i pacchetti nuget siano installati regolarmente ed aggiornati all'ultima release stabile.
   In caso negativo provare ad effettuare un ripristino dei pacchetti o in alternativa tramite "Console di Gestione pacchetti"
   eseguite il seguente comando: "update-package -reinstall".
5. Avviate l'applicazione.
6. Effettuate il Login con l'utente "developer" password "dev".
7. Andate su Init DB e  cliccate su Aggiorna Struttura e successivamente su Inizializza Dati.
8. Chiudete l'applicazione.
9. Impostate a FALSE la chiave InitDB presente nella sezione AppSettings del file web.config.
10. Se tutti i passaggi precedenti sono andati a buon fine potete iniziare a sviluppare la vostra applicazione.

Per eventuali problemi potete consultare il sito web https://www.b-arts.eu o inviare una email al seguente indirizzo: info@b-arts.eu

Buon Lavoro
