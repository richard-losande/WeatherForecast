import React, { Component } from "react";
import { BrowserRouter,Switch, Route } from "react-router-dom";
import WeatherForecasts from "./components/weatherforecast";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <BrowserRouter>    
      <Switch>
              <Route path="/" exact component={WeatherForecasts} />
      </Switch>
      </BrowserRouter>
    );
  }
}
