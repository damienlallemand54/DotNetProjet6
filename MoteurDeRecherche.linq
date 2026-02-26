<Query Kind="Program">
  <Connection>
    <ID>603cc987-d25b-4cb7-ac10-6af1e5322a7d</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <UseMicrosoftDataSqlClient>true</UseMicrosoftDataSqlClient>
    <EncryptTraffic>true</EncryptTraffic>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>NexaWorksDB</Database>
    <MapXmlToString>false</MapXmlToString>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	string statutFiltre = null; 
	string nomProduitFiltre = null; 
	string nomVersionFiltre = null;
	string motCle = null; 
	DateTime? dateDebut = null;
	DateTime? dateFin = null;
	
	var query = from t in Tickets
				join v in Versions on t.VersionId equals v.Id
				join p in Produits on v.ProduitId equals p.Id
				join s in SystemeExploitations on t.OSId equals s.Id
				select new {
					t.Id,
					t.DateCreation,
					t.Statut,
					Produit = p.Nom,
					Version = v.Numero,
					OS = s.Nom,
					t.Probleme,
					t.Resolution
				};
	
	if (!string.IsNullOrEmpty(statutFiltre))
		query = query.Where(q => q.Statut == statutFiltre);

	if (!string.IsNullOrEmpty(nomProduitFiltre))
		query = query.Where(q => q.Produit == nomProduitFiltre);

	if (!string.IsNullOrEmpty(nomVersionFiltre))
		query = query.Where(q => q.Version == nomVersionFiltre);

	if (!string.IsNullOrEmpty(motCle))
		query = query.Where(q => q.Probleme.Contains(motCle)||q.Resolution.Contains(motCle));
	
	if (dateDebut.HasValue && dateFin.HasValue)
		query = query.Where(q => q.DateCreation >= dateDebut && q.DateCreation <= dateFin);

	query.Dump();
}