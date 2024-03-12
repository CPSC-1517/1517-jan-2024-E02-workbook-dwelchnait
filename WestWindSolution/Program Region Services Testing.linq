<Query Kind="Program">
  <Connection>
    <ID>b06a3ef6-d1e5-4b4f-bf10-f85fff096f18</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WestWind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//web page
	
	// variables on the web page
	List<Regions> info = new List<Regions>();
	
	//OnInitialize() method
	info = Region_Get();
	info.Dump();
	
	// variables on the web page
	int regionidarg = 3; //this value would actually come from input control
	Regions aRegion = new Regions();
	
	//Fetch_Region()  search method
	aRegion = Region_GetByID(regionidarg);
	aRegion.Dump();
}

// You can define other methods, fields, classes and namespaces here

// BLL method RegionServices class
public List<Regions> Region_Get()
{
	IEnumerable<Regions> info = Regions.OrderBy(r => r.RegionDescription );
	return info.ToList();
	
}

public Regions Region_GetByID(int regionid)
{
	IEnumerable<Regions> info = Regions
						.Where(r => r.RegionID == regionid);
	return info.FirstOrDefault( );
								
	
}


