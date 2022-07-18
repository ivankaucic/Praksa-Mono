import React from 'react';
import './Form.css';

function Form(props) {
  return (
    <form className="bookForm">
        <div>
            <label>{props.firstLabel}</label>
            <input type="text" id="bookId" placeholder="enter bookId" required /><br/>
        </div>
        <div>
            <label>{props.secondLabel}</label>
            <input type="text" id="bookName" placeholder="enter bookName" required /><br/>
        </div>
        <div>
            <label>{props.thirdLabel}</label>
            <input type="text" id="bookAuthor" placeholder="enter bookAuthor" required /><br/>
        </div>
        <div>
            <label>{props.fourthLabel}</label>
            <input type="number" id="bookPrice" placeholder="enter bookPrice" required /><br/>
        </div>
    </form>
  )
}

export default Form