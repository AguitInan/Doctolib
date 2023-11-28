# Doctolib_v2
Final version of the Doctolib project.

****Description des classes****

**1. AbstractModelWithNotification.cs**

**Description**

Cette classe abstraite implémente l'interface INotifyPropertyChanged, permettant ainsi aux classes dérivées de notifier les changements de propriétés aux vues dans une architecture MVVM.

**Méthodes**

void RaisePropertyChange(string propertyName): Déclenche l'événement PropertyChanged pour la propriété spécifiée.

**2. Medecin.cs**

**Description**

La classe Medecin hérite de AbstractModelWithNotification et gère les informations et les opérations de base de données pour un médecin.

**Propriétés**

Id, CodeMedecin, NomMedecin, TelMedecin, DateEmbauche, SpecialiteMedecin: Stockent les informations sur un médecin et notifient les changements de propriétés.

**Méthodes**

bool Save(): Enregistre un nouveau médecin dans la base de données.

bool Delete(): Supprime un médecin de la base de données.

bool Update(): Met à jour les informations d'un médecin dans la base de données.

List<Medecin> GetMedecins(): Récupère une liste de tous les médecins de la base de données.

Medecin GetMedecinById(string codeMedecin): Récupère un médecin spécifique en utilisant son codeMedecin.

List<string> GetCodeMedecin(): Récupère une liste de tous les codes de médecin.

List<Medecin> SearchMedecins(string search): Récupère une liste de médecins basée sur une chaîne de recherche.



**3. Patient.cs**

**Description**

La classe Patient est similaire à Medecin mais gère les informations et les opérations de base de données pour un patient.

**Propriétés**

Id, CodePatient, NomPatient, AdressePatient, DateNaissance, SexePatient: Stockent les informations sur un patient et notifient les changements de propriétés.

**Méthodes**

bool Save(), bool Delete(), bool Update(): Méthodes CRUD similaires à celles de la classe Medecin.

List<Patient> GetPatients(): Récupère une liste de tous les patients.

Patient GetPatientById(string codePatient): Récupère un patient spécifique.

List<string> GetCodePatient(): Récupère une liste de tous les codes de patient.

List<Patient> SearchPatients(string search): Récupère une liste de patients basée sur une chaîne de recherche.


**4. RDV.cs**

**Description**

La classe RDV gère les informations et les opérations de base de données pour un rendez-vous (RDV).

**Propriétés**

Id, NumeroRDV, DateRDV, HeureRDV, CodeMedecin, CodePatient: Stockent les informations sur un RDV et notifient les changements de propriétés.

**Méthodes**

bool Save(), bool Delete(): Méthodes CRUD pour les RDV.

List<RDV> GetRdvs(): Récupère une liste de tous les RDV.

List<RDV> SearchRdvsByDate(string search): Récupère une liste de RDV basée sur une date.

List<RDV> SearchRdvsByPatient(string search): Récupère une liste de RDV basée sur un code patient.

**5. Specialite.cs**

**Description**

La classe Specialite stocke des informations sur une spécialité médicale.

**Propriétés**

IdSpecialite: Identifiant de la spécialité.
IntituleSpecialite: Nom de la spécialité.



**Description des vues**

**1. MainViewModel**

**Description**

MainViewModel est responsable de la gestion des commandes qui déterminent quelle vue (sous forme de contrôle utilisateur) est actuellement affichée dans l'interface principale.

**Propriétés**

ICommand MedecinCommand: Commande pour afficher la vue des médecins.

ICommand PatientCommand: Commande pour afficher la vue des patients.

ICommand RDVCommand: Commande pour afficher la vue des rendez-vous.

ICommand RDVDisplayCommand: Commande pour afficher la vue détaillée des rendez-vous.

ICommand RDVPatientCommand: Commande pour afficher la vue des rendez-vous pour un patient spécifique.

ICommand ExitCommand: Commande pour fermer l'application.

**Méthodes**

void ActionExitCommand(): Ferme la fenêtre principale de l'application.

**2. MedecinViewModel**

**Description**

MedecinViewModel gère les opérations CRUD (Création, Lecture, Mise à jour, Suppression) pour les objets Medecin et met à jour l'interface utilisateur en conséquence.

**Propriétés**

Medecin Medecin: L'objet médecin actuellement sélectionné ou manipulé.

ObservableCollection<Medecin> Medecins: Collection des objets Medecin récupérés depuis la base de données.

ObservableCollection<string> Specialites: Collection des spécialités médicales disponibles.

ICommand AddCommand, DeleteCommand, ModifyCommand, SearchCommand: Commandes pour ajouter, supprimer, modifier et rechercher des médecins.

**Méthodes**

void ActionAddCommand(): Ajoute un nouveau médecin à la base de données et à Medecins.

void ActionDeleteCommand(): Supprime le médecin sélectionné de la base de données et de Medecins.

void ActionModifyCommand(): Met à jour le médecin sélectionné dans la base de données.

void ActionSearchCommand(): Met à jour Medecins avec les résultats de la recherche.

void RaiseAllChanged(): Déclenche les notifications de changement de propriété pour mettre à jour l'UI.

**3. PatientViewModel**

**Description**

PatientViewModel est similaire à MedecinViewModel, mais gère les objets Patient.

**Méthodes**

void ActionAddCommand(): Ajoute un nouveau patient.

void ActionDeleteCommand(): Supprime le patient sélectionné.

void ActionModifyCommand(): Met à jour le patient sélectionné.

void ActionSearchCommand(): Met à jour Patients avec les résultats de la recherche.

void RaiseAllChanged(): Notifie les changements de propriété.

**4. RDVDisplayViewModel et RDVPatientViewModel**

**Description**

Ces deux ViewModel gèrent l'affichage et les interactions avec les objets RDV (rendez-vous). RDVDisplayViewModel est axé sur l'affichage des détails des rendez-vous, tandis que RDVPatientViewModel semble être axé sur la gestion des rendez-vous pour des patients spécifiques.

Ces deux ViewModel gèrent l'affichage et les interactions avec les objets RDV (rendez-vous). RDVDisplayViewModel est axé sur l'affichage des détails des rendez-vous, tandis que RDVPatientViewModel semble être axé sur la gestion des rendez-vous pour des patients spécifiques.

**Méthodes**

void ActionSearchCommand(): Recherche et met à jour la liste des rendez-vous.

void RaiseAllChanged(): Notifie les changements de propriété.

**5. RDVViewModel**

**Description**

RDVViewModel gère les opérations CRUD pour les objets RDV.

**Méthodes**

void ActionAddCommand(): Ajoute un nouveau rendez-vous.

void ActionNewCommand(): Réinitialise l'objet RDV pour permettre l'entrée d'un nouveau rendez-vous.

void ActionExitCommand(): Ferme l'application.

void RaiseAllChanged(): Notifie les changements de propriété.
