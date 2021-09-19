export const getWeatherForecast = (formData) => {
    return new Promise((resolve, reject) => {
      fetch("api/WeatherForecasts/Details", {
        method: "GET",
        credentials: "same-origin",
        params : formData,
        headers: {
          Accept: "application/json, text/plain, */*",
          "Content-Type": "application/json"
        }
      })
        .then(response => response.json())
        .then(data => {
          resolve(data);
        })
        .catch(err => reject(err));
    });
  };