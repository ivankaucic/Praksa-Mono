import React, { useState } from 'react';
import './Form.css';
import Button from './Button.js';
import Table from './Table.js';

function Form(props) {

    const[book,   setBook] = useState({});
    const[bookList, setBookList] = useState([]);
    const[error, setError] = useState("");

    function handleChage(e){        
        setBook({...book, [e.target.name]:e.target.value});
    }

    function checkIfEmpty(value){
        if(!value){setError("Empty");}
        else{setError("");}
    }

    function handleSubmit(){
        setBookList([...bookList,book]);
        checkIfEmpty(book.bookId);
        checkIfEmpty(book.bookName);
        checkIfEmpty(book.bookAuthor);
        checkIfEmpty(book.bookPrice);
        setBook({
            bookId : "",
            bookName : "",
            bookAuthor : "",
            bookPrice : ""
        });
    }
    
  return (
    <div>
        <form className="bookForm">
            <div>
                <label>{props.firstLabel}</label>
                <input type="text" name="bookId" value={book.bookId} onChange={handleChage} required /><br/>
            </div>
            <div>
                <label>{props.secondLabel}</label>
                <input type="text" name="bookName" value={book.bookName} onChange={handleChage} required /><br/>
            </div>
            <div>
                <label>{props.thirdLabel}</label>
                <input type="text" name="bookAuthor" value={book.bookAuthor} onChange={handleChage} required /><br/>
            </div>
            <div>
                <label>{props.fourthLabel}</label>
                <input type="number" name="bookPrice" value={book.bookPrice} onChange={handleChage} required /><br/>                
            </div>  
            {error && <p>{error}</p>}          
            <Button message="submit me" functionName={handleSubmit}/>            
        </form>
        <Table bookId="ID" bookName="Title" bookAuthor="Author" bookPrice="Price" bookList={bookList}/>
    </div>
  )
}

export default Form