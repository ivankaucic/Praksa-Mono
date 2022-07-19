import './App.css';
import Form from './Form.js';
import Navbar from './NavBar.js';
import sound from './song.mp3';
import Quiz from './Quiz.js';

function App() {
  return (
    <div className="flex-container">
      <Navbar navItemNameOne="Home" navItemNameTwo="Info" navItemNameThree="Books" navItemNameFour="Authors"/>      
      <Form firstLabel="Enter book ID: " secondLabel="Enter book name: " thirdLabel="Enter book author: " 
            fourthLabel="Enter book price: "/>     
      <audio autostart="true" autoplay="true" loop="true">
        <source src={sound} type="audio/mpeg"/>
      </audio> 
      <Quiz/>
    </div>    
  );
}

export default App;
