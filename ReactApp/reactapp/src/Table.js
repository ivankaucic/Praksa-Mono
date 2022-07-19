import React from 'react';
import './Table.css';

function Table(props) {
  return (
    <table className="myTable" id="myTable">
      <tbody>
            <tr id="tableHeader">
                <td className="tableHeaderElement" id="bookId">{props.bookId}</td>
                <td className="tableHeaderElement" id="bookName">{props.bookName}</td>
                <td className="tableHeaderElement" id="bookAuthor">{props.bookAuthor}</td>
                <td className="tableHeaderElement" id="bookPrice">{props.bookPrice}</td>
            </tr>
            {props.bookList.map((book) => (
                <tr>
                  <td>{book.bookId}</td>
                  <td>{book.bookName}</td>
                  <td>{book.bookAuthor}</td>
                  <td>{book.bookPrice}</td>
                </tr>
            ))}
      </tbody>
    </table>
  )
}

export default Table;