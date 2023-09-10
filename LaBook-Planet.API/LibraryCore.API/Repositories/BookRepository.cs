using AutoMapper;
using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace LaBook_Planet.API.LibraryCore.API.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LaBookContextApi _context;
    private readonly IMapper _mapper;

    public BookRepository(LaBookContextApi context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        var books = _context.Books;
        return books;
    }

    public async Task<Book> GetBookById(string id)
    {
        var result = _context.Books.FirstOrDefault(s => s.Id == id);
        if (result != null)
            return result;

        return new Book();
    }

    public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetPopularBooks(int pageSize = 10, int pageNumber = 1)
    {
        var popularBooks = _context.Books
            .OrderByDescending(book => book.CreatedAt)
            .Select(book => new GetAllBooksDto
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
                IsAvailable = book.AvailableCopies > 0,
            });

        var paginatedPopularBooks = await popularBooks.PaginationAsync<GetAllBooksDto>(pageSize, pageNumber);

        return Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(paginatedPopularBooks);
    }

    public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetRecentBooks(int pageSize = 10, int pageNumber = 1)
    {
        var books = _context.Books
        .OrderByDescending(book => book.CreatedAt)
        .Select(book => new GetAllBooksDto
        {
            BookId = book.Id,
                 Title = book.Title,
                 Author = book.Author,
                 IsAvailable = book.AvailableCopies > 0,
             });

        var paginatedBooks = await books.PaginationAsync<GetAllBooksDto>(pageSize, pageNumber);

        return Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(paginatedBooks);
    }

    public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> SearchBooks(string keyword, int pageSize = 10, int pageNumber = 1)
    {
        var books = _context.Books
            .Where(book => book.Title.Contains(keyword) || book.Genre.Name.Contains(keyword) || book.Author.Contains(keyword))
            .OrderByDescending(book => book.CreatedAt)
            .Select(book => new GetAllBooksDto
            {
                BookId = book.Id,
                Title = book.Title,
                Author = book.Author,
                IsAvailable = book.AvailableCopies > 0,
            });

        var paginatedBooks = await books.PaginationAsync<GetAllBooksDto>(pageSize, pageNumber);

        return Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>.Success(paginatedBooks);
    }

    
}