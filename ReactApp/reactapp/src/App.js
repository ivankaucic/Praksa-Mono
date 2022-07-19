import './App.css';
import Form from './Form.js';
import Navbar from './NavBar.js';
import sound from './song.mp3';
import Dropdown from './Dropdown.js';
import React, { useState } from 'react';

function App() {  

  const[countryList] = useState([ { id: 1, name: "Banana" },
                                                  { id: 2, name: "Apple" },
                                                  { id: 3, name: "Pear" },
                                                  { id: 4, name: "Fig" },
                                                  { id: 5, name: "Orange" },
                                                  { id: 6, name: "Watermelon" },
                                                  { id: 7, name: "Calaope" },
                                                  { id: 8, name: "Kiwi" },
                                                  { id: 9, name: "Grape" },
                                                  { id: 10, name: "Cherry" }]);

  return (
    <div className="flex-container">
      <Navbar navItemNameOne="Home" navItemNameTwo="Info" navItemNameThree="Books" navItemNameFour="Authors"/>      
      <Form firstLabel="Enter book ID: " secondLabel="Enter book name: " thirdLabel="Enter book author: " 
            fourthLabel="Enter book price: "/>     
      <audio autostart="true" autoplay="true" loop="true">
        <source src={sound} type="audio/mpeg"/>
      </audio> 
      <Dropdown defaultText="Please set an option" optionsList={countryList}/>
    </div>    
  );
}

export default App;
