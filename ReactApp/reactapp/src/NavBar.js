import React from 'react';
import Button from './Button.js';
import './NavBar.css';

function NavBar(props) {
  return (
        <ul className="navBar">
            <li>{props.navItemNameOne}</li>
            <li>{props.navItemNameTwo}</li>
            <li>{props.navItemNameThree}</li>
            <li>{props.navItemNameFour}</li>
        </ul>
  )
}

export default NavBar;