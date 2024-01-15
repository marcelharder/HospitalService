namespace HospitalService.helpers;

public class PaginationHeader
{

  public int CurrentPage {get; set;}
  public int ItemsPerPage {get; set;}
  public int Totalitems {get; set;}
  public int TotalPages{get; set;}

  public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
  {
    CurrentPage = currentPage;
    ItemsPerPage = itemsPerPage;
    TotalPages = totalPages;
    totalItems = totalItems;

  }
  
}