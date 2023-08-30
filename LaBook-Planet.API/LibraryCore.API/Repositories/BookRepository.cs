using AutoMapper;
using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.LibraryCore.API.DTOs;
using Library.Core.Utilities;
using Microsoft.AspNetCore.Mvc;

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

     public bool AddBook(Book book)
     {
        _context.Add(book);
        _context.SaveChanges();
        return true;
     }

    public async Task<Result<BookDetailsDto>> UpdateBook(string id, BookDetailsDto updatedBook)
    {
        var existingBook = await _context.Books.FindAsync(id);

        if (existingBook == null)
        {
            existingBook.Author = updatedBook.Author;
            existingBook.Title = updatedBook.Title;

            try
            {
                await _context.SaveChangesAsync();
                return Result<BookDetailsDto>.Success(updatedBook);
            }
            catch (Exception ex)
            {
                throw new Exception();
                // Handle update error
                //return Result<BookDetailsDto>.Fail($"Error updating book with id: {id}");
            }
        }

        var bookDto = _mapper.Map<BookDetailsDto>(existingBook);

        return Result<BookDetailsDto>.Success(bookDto);
       
    }


    public async Task<Result<PaginatorResponseDto<IEnumerable<GetAllBooksDto>>>> GetAllBooks(int pageSize = 10, int pageNumber = 1)
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

    public async Task<Result<BookDetailsDto>> GetBookById(string id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return Result<BookDetailsDto>.Fail(new[] { "Book not found" });
        }

        var bookDto = _mapper.Map<BookDetailsDto>(book);

        return Result<BookDetailsDto>.Success(bookDto);
    }

    public bool GetBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return true;
    }


    public bool DeleteBook(Book book)
    {
        _context.Remove(book);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteBook(object existingBookc)
    {
        throw new NotImplementedException();
    }
}