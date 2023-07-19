using static System.Net.Mime.MediaTypeNames;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json)!;
        }
    }
    public IEnumerable<Book> ColeccionCompleta()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesDel2000()
    {
        //Extension Method
        //return librosCollection.Where(p=> p.publishedDate.Year > 2000);

        //Query Expression
        return from l in librosCollection
               where l.publishedDate.Year > 2000
               select l;
    }
    /// <summary>
    /// Retornar libros con mas de 250 paginas y titulo que contenga palabras in Action
    /// </summary>
    public IEnumerable<Book> SegundoReto()
    {
        //Extension Method
        //return librosCollection.Where(p=> p.pageCount > 250 && p.title.Contains("in Action"));

        //Query Expression
        return from l in librosCollection
               where l.pageCount > 250 && l.title.Contains("in Action")
               select l;
    }
    /// <summary>
    /// Valida que el STATUS de los libros no este vacio y con el Metodo ALL hace referencia que todos absolutamente todos los libros deben tener el status diligenciados para que no devuelva un False
    /// </summary>
    public bool TodosLosLibrosTieneStatus()
    {
        return librosCollection.All(p => p.status != string.Empty);
    }
    /// <summary>
    /// Valida que al menos uno de todos los libros fue lanzado o publicado en el año 2005 para devolver un True
    /// </summary>
    public bool AlMenosUnLibroFueLanzadoEn2005()
    {
        return librosCollection.Any(p => p.publishedDate.Year == 2005);
    }
    /// <summary>
    /// Trae los libros que en su categoria contiene la palabra Python
    /// </summary>
    public IEnumerable<Book> LibrosdePython()
    {
        return librosCollection.Where(p => p.categories.Contains("Python"));
    }
    /// <summary>
    /// Trae los libros que en su categoria contiene la palabra Java y ordenados por nombre
    /// </summary>
    public IEnumerable<Book> LibrosdeJavaOrdenadosAsc()
    {
        return librosCollection.Where(p => p.categories.Contains("Java")).OrderBy(p => p.title);
    }
    /// <summary>
    /// Trae los libros que tienen mas de 450 paginas ordenados por numero de paginas de manera desc
    /// </summary>
    public IEnumerable<Book> LibrosMas450PagOrdenadosDesc()
    {
        return librosCollection.Where(p => p.pageCount > 450).OrderByDescending(p => p.pageCount);
    }
    /// <summary>
    /// Trae los 3 primeros libros con la fecha de publicacion mas reciente y que son categorizados en java
    /// </summary>
    public IEnumerable<Book> TresLibrosMasRecientesDeJava()
    {
        return librosCollection.Where(p => p.categories.Contains("Java")).OrderByDescending(p => p.publishedDate).Take(3);
    }
    /// <summary>
    /// Trae el tercer y cuarto libro de tiene mas de 400 paginas
    /// </summary>
    public IEnumerable<Book> TerceryCuartoLibroMas400Pag()
    {
        //[1, 2, 3, 4, 5, 6, 7].take(4) = [1, 2, 3, 4]
        //[1, 2, 3, 4].TaskLast(2) = [3, 4]
        return librosCollection.Where(p => p.pageCount > 400).Take(4).Skip(2); //Skip omite los primeros 2 valores de la lista
    }
    /// <summary>
    /// Trae los 3 primeros libros filtrados con SELECT
    /// </summary>
    public IEnumerable<Book> TresPrimerosLibros()
    {
        return librosCollection.Take(3).Select(p => new Book() { title = p.title, pageCount = p.pageCount });
    }
    /// <summary>
    /// Trae el numero de libros que tengan entre 200 y 500 paginas
    /// </summary>
    public int NumeroLibrosEntre200y500pag()
    {
        return librosCollection.Count(p => p.pageCount >= 200 && p.pageCount <= 500);
    }
    /// <summary>
    /// usar MIN para retornar la fecha de publicacion menor
    /// </summary>
    public DateTime FechadePublicacionMenor()
    {
        return librosCollection.Min(p => p.publishedDate);
    }
    /// <summary>
    /// usar MAX para retornar el numero de paginas del libro con mas paginas
    /// </summary>
    public int NumeroPaginasLibroMayor()
    {
        return librosCollection.Max(p => p.pageCount);
    }
    /// <summary>
    /// usar MinBy para retornar el libro con menor cantidad de paginas mayor a 0
    /// </summary>
    public Book LibroConMenorPag()
    {
        return librosCollection.Where(p => p.pageCount > 0).MinBy(p=> p.pageCount)!;
    }
    /// <summary>
    /// usar MaxBy para retornar el libro con la fecha mas reciente
    /// </summary>
    public Book LibroFechaMasReciente()
    {
        return librosCollection.MaxBy(p=> p.publishedDate)!;
    }
    /// <summary>
    /// usar Sum para retornar el total de las paginas de los libros entre 0 y 500 paginas
    /// </summary>
    public int SumaPaginasDeLibros0y500Pag()
    {
        return librosCollection.Where(p => p.pageCount >= 0 && p.pageCount <= 500).Sum(p=> p.pageCount);
    }
    /// <summary>
    /// usar Aggreagte para retornar el titulo de los libros que tienen fecha de publicacion posterior a 2015
    /// </summary>
    public String TitulosLibrosDespuesdel2015Concatenados()
    {
        return librosCollection
            .Where(p => p.publishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                    TitulosLibros += " - " + next.title;
                else
                    TitulosLibros += next.title;
                return TitulosLibros;
            });
    }
    /// <summary>
    /// usar Average para retornar el promedio de caracteres que tiene los titulos de la coleccion
    /// </summary>
    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p => p.title.Length);    
    }
    /// <summary>
    /// usar GroupBy para retornar todos los libros que fueron publicados a partir del 2000, agrupados por año
    /// </summary>
    public IEnumerable<IGrouping<int, Book>> LibrosDespuesdel2000AgrupadosYear ()
    {
        return librosCollection.Where(p => p.publishedDate.Year > 2000).GroupBy(p=> p.publishedDate.Year);
    }
    /// <summary>
    /// usar ToLookup para retornar un diccionario que permita consultar los libros de acuerdo a la letra con la que inicia el titulo del libro
    /// </summary>
    public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p => p.title[0], p=> p);
    }

    /// <summary>
    /// Obtener una coleccion que tenga todos los libros con mas de 500 paginas y otra que contenga los libros publicados despues del 2005
    /// Utilizando Join retornar los libros que esten en ambas colecciones
    /// </summary>
    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Pag()
    {
        var librosDespuesDel2005 = librosCollection.Where(p => p.publishedDate.Year > 2005);
        var librosConMasDe500Pag = librosCollection.Where(p => p.pageCount > 500);

        return librosDespuesDel2005.Join(librosConMasDe500Pag, p => p.title, x => x.title, (p, x) => p);
    }
}

   

