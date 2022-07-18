//rfce
import React from 'react';
import './Button.css';

function addBooks(){
    var table = document.getElementById("myTable");
    var row = table.insertRow();
    var cellId = row.insertCell();
    var cellBookName = row.insertCell();
    var cellBookAuthor = row.insertCell();
    var cellBookPrice = row.insertCell();

    var bookId = document.getElementById("bookId").value;
    var bookName = document.getElementById("bookName").value;
    var bookAuthor = document.getElementById("bookAuthor").value;
    var bookPrice = document.getElementById("bookPrice").value;

    cellId.innerHTML = bookId;
    cellBookName.innerHTML = bookName;
    cellBookAuthor.innerHTML = bookAuthor;
    cellBookPrice.innerHTML = bookPrice;
}


function Button(props) {
  return (
    <input type="button" value={props.message} id="addBookBtn" onClick={addBooks}/>
  )
}

export default Button;