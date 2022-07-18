import React from 'react';
import './Table.css';

function Table(props) {
  return (
    <table className="myTable" id="myTable">
            <tr id="tableHeader">
                <td className="tableHeaderElement" id="bookId">{props.bookId}</td>
                <td className="tableHeaderElement" id="bookName">{props.bookName}</td>
                <td className="tableHeaderElement" id="bookAuthor">{props.bookAuthor}</td>
                <td className="tableHeaderElement" id="bookPrice">{props.bookPrice}</td>
            </tr>
    </table>
  )
}

export default Table;