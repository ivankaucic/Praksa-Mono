import React from 'react';

function Audio(props) {
  return (
    <audio controls autoplay>
        <source src={props.music}/>
    </audio>
  )
}

export default Audio;