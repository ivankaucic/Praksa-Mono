import React, { Component } from 'react'

export default class Quiz extends Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.newQuestion = this.newQuestion.bind(this);
      }

    newQuestion(){
        return (
            <div>
                <p>Question</p>
                <input type="text">Answer</input>
            </div>

        )
    }

    render() {
        return (
        <div>
            <button onClick={() => this.newQuestion()}>
                Play the Quiz!
            </button>
        </div>
        )
    }
}
