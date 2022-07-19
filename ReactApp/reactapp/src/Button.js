//rfce
import React from 'react';
import './Button.css';

function Button(props) {
  return (
    <input type="button" value={props.message} id="addBookBtn" onClick={props.functionName}/>
  )
}

export default Button;