import React from 'react';
import Route from 'react-router-dom/Route';
import Switch from 'react-router-dom/Switch';
import './App.css';
import HouseList from './HouseList';
import HouseDetail from './HouseDetail';

const App = () => (
  <Switch>
    <Route exact path="/" component={HouseList} />
    <Route exact path="/:id" component={HouseDetail} />
  </Switch>
);

export default App;
