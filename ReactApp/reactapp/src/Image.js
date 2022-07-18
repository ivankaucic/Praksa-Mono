import React from 'react'
import './Image.css';

function Image(props) {
  return (
    <img src={props.source}/>
  )
}

export default Image;