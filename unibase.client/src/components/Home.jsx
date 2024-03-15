import React, { Component } from 'react';
import  JournalAnalitic  from './JournalAnalitic.jsx';
export class Home extends Component {
  static displayName = Home.name;
    render() {
    return (
      <div style={{height: '100%'}}>
        <h1>Приложение  By Tugarin</h1>
        <p>Салам Алейкум!!!!!!</p>
         <JournalAnalitic />
      </div>
    );
  }
}
