LinqQueries queries = new LinqQueries();

//Todos los registros de la coleccion
//ImprimirValores(queries.ColeccionCompleta());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

//Libros segundo reto
//ImprimirValores(queries.SegundoReto());

//Todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTieneStatus()}");

//Al menos un libro fue lanzado en 2005
//Console.WriteLine($"Al menos un libro fue lanzado en 2005? - {queries.AlMenosUnLibroFueLanzadoEn2005()}");

//Libros de Python
//ImprimirValores(queries.LibrosdePython());

//Libros de java ordenados asc
//ImprimirValores(queries.LibrosdeJavaOrdenadosAsc());

//Libros con mas de 450 pag ordenados de manera desc por su numero de pag
//ImprimirValores(queries.LibrosMas450PagOrdenadosDesc());

//3 libros de java mas recientes
//ImprimirValores(queries.TresLibrosMasRecientesDeJava());

//3 y 4 libro con mas de 400 paginas
//ImprimirValores(queries.TerceryCuartoLibroMas400Pag());

//3 libros filtrados
//ImprimirValores(queries.TresPrimerosLibros());

//Numero de libros que tengan mas de 200 y menos de 500 paginas
//Console.WriteLine($"El numero de libros es: {queries.NumeroLibrosEntre200y500pag()}");

//fecha de publicacion menor
//Console.WriteLine($"Fecha de publicacion menor: {queries.FechadePublicacionMenor()}");

//fecha de publicacion menor
//Console.WriteLine($"numero paginas de libro con mas paginas: {queries.NumeroPaginasLibroMayor()}");

//Libro con menor cantidad de paginas
//var libro = queries.LibroConMenorPag();
//Console.WriteLine($"libro con menos paginas: {libro.title} tiene {libro.pageCount} paginas");

//Libro con fecha mas reciente
//var libro = queries.LibroFechaMasReciente();
//Console.WriteLine($"Libro con fecha mas reciente: {libro.title} su fecha es: {libro.publishedDate.ToShortDateString()}");

//total paginas de los libros que tenga hasta 500 paginas
//Console.WriteLine($"La suma total es de: {queries.SumaPaginasDeLibros0y500Pag()} paginas");

//Libros publicados despues del 2015
//Console.WriteLine(queries.TitulosLibrosDespuesdel2015Concatenados());

//Promedio de caracteres titulo de los libros
//Console.WriteLine($" Promedio de los caracteres: {queries.PromedioCaracteresTitulo()}");

//Libros publicados a partir del 2000 agrupados por año
//ImprimirGrupo(queries.LibrosDespuesdel2000AgrupadosYear());

//Diccionario de libros por primera letra del titulo
//var diccionariolookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionariolookup, 'Z');

//Libros filtrados con Join
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Pag());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros) 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.title, item.pageCount, item.publishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.title, item.pageCount, item.publishedDate.Date.ToShortDateString());
        }
    }
}
void ImprimirDiccionario(ILookup<char, Book> bookList, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in bookList[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.title, item.pageCount, item.publishedDate.Date.ToShortDateString());
    }

}
