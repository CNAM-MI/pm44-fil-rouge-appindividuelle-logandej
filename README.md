# Next Drink

Next Drink est une application mobile développée en MAUI .NET C#. L'objectif de l'application est de faciliter la planification de sorties au bar pour les groupes d'étudiants.

## Fonctionnalités

### Création de sondage

- Pour créer un sondage, il est nécessaire d'avoir un compte.
- Lors de la création d'un sondage, une suggestion est proposée pour aller boire un verre avant la fin de la semaine en cours.
- Le créateur du sondage doit choisir un titre, un temps pour voter pour le jour de la semaine (30 min, 1h, 2h, 5h) et un temps pour voter pour l'heure (5 min, 30 min, 1h, 2h).
- Une fois qu'un sondage est créé, personne ne peut en créer un autre.

| Temps de vote pour le jour | Temps de vote pour l'heure |
| --- | --- |
| 15 min | 5 min |
| 30 min | 10 min |   
| 1h   | 30 min |   
| 2h   | 1h |   
| 5h   | 2h |   

<table>
  <tr>
    <td><img src="src/createVote.png" alt="createVote" width="200"></td>
    <td><img src="src/timerDay.png" alt="timerDay" width="200"></td>
    <td><img src="src/timerHour.png" alt="timerHour" width="200"></td>
  </tr>
</table>


### Vote

- Les utilisateurs ont le temps défini par le créateur du sondage pour voter pour le jour de la semaine.
- Le vote se fait en penchant le téléphone de gauche à droite pour faire bouger un curseur autour d'un demi-cercle séparé en 7 parties représentant les 7 jours de la semaine.
#### Jours de la semaine

| Lundi | Mardi | Mercredi | Jeudi | Vendredi | Samedi | Dimanche |
| --- | --- | --- | --- | --- | --- | --- |
- Les jours précédents le jour actuel sont grisés et ne peuvent pas être sélectionnés.
- Pendant le vote, les parties du cercle sont plus foncées ou non pour donner une indication sur les votes en cours.
- Une fois que le temps pour voter pour le jour est écoulé, le jour est sélectionné et le vote pour l'heure commence.
- Le vote pour l'heure se fait de la même manière que le vote pour le jour, en utilisant un demi-disque séparé de 12h à 23h.
#### Heures

| 12h | 13h | 14h | 15h | 16h | 17h | 18h | 19h | 20h | 21h | 22h | 23h |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
- Le vote qui a reçu le plus de voix est sélectionné.
- L'indicateur de vote permet d'influencer le vote pour rassembler le maximum de personnes pour l'événement.

<table>
  <tr>
    <td><img src="src/voteday.jpg" alt="voteday" width="200"/></td>
 <td><img src="src/votehour.jpg" alt="votehour" width="200"/></td>
  </tr>
</table>

### Technologies utilisées

**Client:** MAUI .NET, C#, XAML

**Server:** Node.js, JavaScript

**Communication:** Socket.io 


## Développement 

### Avantages et inconvénients de MAUI .NET

#### Avantages

| Avantage | Description |
| --- | --- |
| Multiplateforme | MAUI .NET permet de développer des applications pour plusieurs plateformes (Android, iOS, Windows, etc.) à partir d'une seule base de code, ce qui réduit les coûts et les délais de développement. |
| Hot Reload | La fonctionnalité Hot Reload de MAUI .NET permet de voir les modifications apportées au code en temps réel, sans avoir à redémarrer l'application, ce qui accélère le processus de développement. |
| C# | MAUI .NET utilise le langage de programmation C#, qui est populaire et puissant, avec une syntaxe familière pour les développeurs .NET. |
| Bibliothèques et outils | MAUI .NET offre un grand nombre de bibliothèques et d'outils pour faciliter le développement d'applications, tels que Xamarin.Forms, NuGet, etc. |

*Notes du développeur :*


* *Le Hot Reload est une fonctionnalité qui m'a beaucoup servie pour changer et afficher les vues dynamiquement.*

* *Ayant déjà développé en Xamarin, prédécesseur de MAUI .NET, j'ai vite compris comment l'architecture fonctionnait, une vue XAML liée à son fichier C#, très pratique pour faire du binding de données.*

#### Inconvénients

| Inconvénient | Description |
| --- | --- |
| Complexité | MAUI .NET peut être plus complexe à apprendre et à utiliser que d'autres frameworks de développement d'applications mobiles, en particulier pour les développeurs qui ne sont pas familiers avec .NET. |
| Performances | Les applications développées avec MAUI .NET peuvent avoir des performances légèrement inférieures à celles développées avec des frameworks natifs, en raison de la couche d'abstraction supplémentaire. |
| Compatibilité | Il peut y avoir des problèmes de compatibilité avec certaines fonctionnalités ou bibliothèques spécifiques à une plateforme lors du développement d'applications multiplateformes avec MAUI .NET. |

*Notes du développeur :*


* *J'ai dû modifier et ajouter des balises dans le projet sur des fichiers de configuration pour que Socket.io fonctionne, ça m'a pris beaucoup de temps à trouver*

* *L'application actuelle fonctionne avec un Package Nuget sous licence (SyncFusion) pour les graphes (donut chart). Il existerait une solution gratuite pour des résultats identiques.*

### Base de données

<img src="src/bdd.png" alt="bdd" width="400"/>


### Connexion au serveur en Socket.io
```c#
 Console.WriteLine("CONNECTION TO SERVER");
 string serverUri = "http://84.235.235.229:3000/";

 try
 {
     var client = new SocketIOClient.SocketIO(serverUri);

     await client.ConnectAsync();
     Console.WriteLine("client = "+client);

     //Envoi du message "Talk To Me" au serveur
     await client.EmitAsync("talktome", new { message = "Je suis connecté !" });

     //Ecoute la réponse "hi" du serveur
     client.On("hi", response =>
     {
         Console.WriteLine(response);
         string text = response.GetValue<string>();

     });

 }
 catch (Exception ex)
 {
     Console.WriteLine("Connection failed"+ex.Message);
 }
```

