﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(b => b.Id == bookId));
        }

        public IDataResult<List<Book>> GetList()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList().ToList());
        }

        public IDataResult<List<Book>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetList(b => b.CategoryId == categoryId).ToList());
        }

        public IResult Add(Book book)
        {
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }
    }
}
