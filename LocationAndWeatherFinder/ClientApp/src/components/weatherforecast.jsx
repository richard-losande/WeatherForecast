import React, {Component} from "react";
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import { withStyles } from '@material-ui/core/styles';

const styles = theme => ({
    container: {
        display: 'flex',
        flexWrap: 'wrap',
        backgroundColor: 'white'
    },
    textField: {
        marginBottom : theme.spacing(2)
        
      },
      label:{
        fontSize : 20,
        color :  "blue"
      },
      dense: {
        marginTop: 16,  
      },
      menu: {
        width: 200,
      },
      input: {
        display: 'none',
      },
      marginRight :{
          marginRight : 20,
      },
      selectEmpty: {
        marginTop: theme.spacing(2),
      },
})
class WeatherForecast extends Component{
    state = {
        weatherForecasts: [],
      };
    
      changeHandler = (e) => {
          console.log(e.target.files[0]);
        var formdata = new FormData();
        formdata.append("File", e.target.files[0]);
        fetch("api/WeatherForecasts/Details", {
            method: "POST",
            credentials: "same-origin",
            body : formdata,
          }).then((response) => response.json())
          .then((result) => {
              console.log('Success:', result);
              this.setState({weatherForecasts: result.data}) 
              console.log(this.state.weatherForecasts);
          })
          .catch((error) => {
              console.error('Error:', error);
          });           
	};

    render() {
    return(
            <React.Fragment>
                <CssBaseline />
                <Container maxWidth="sm">   
                <input type="file" name="file" onChange={this.changeHandler} />
                <TableContainer component={Paper}>
                  <Table aria-label="simple table">
                    <TableHead>
                      <TableRow>
                        <TableCell>City</TableCell>
                        <TableCell>Country</TableCell>
                        <TableCell>Latitude</TableCell>
                        <TableCell>Longitude</TableCell>
                        <TableCell>Description</TableCell>
                        <TableCell>Humidity</TableCell>
                        <TableCell>TempFeelsLike</TableCell>
                        <TableCell>TempMax</TableCell>
                        <TableCell>TempMin</TableCell>
                        <TableCell>WeatherIcon</TableCell>
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {this.state.weatherForecasts.map((data,index) => (
                        <TableRow key={`id_${index}`}>
                          <TableCell>{data.city}</TableCell>
                          <TableCell>{data.country}</TableCell>
                          <TableCell>{data.lat}</TableCell>
                          <TableCell>{data.lon}</TableCell>
                          <TableCell>{data.description}</TableCell>
                          <TableCell>{data.humidity}</TableCell>
                          <TableCell>{data.tempFeelsLike}</TableCell>
                          <TableCell>{data.tempMax}</TableCell>
                          <TableCell>{data.tempMin}</TableCell>
                          <TableCell><div><img src={`http://openweathermap.org/img/w/${data.weatherIcon}.png`}/></div></TableCell>
                        </TableRow>
                      ))}
                    </TableBody>
                  </Table>
                </TableContainer>   
                 </Container>
              </React.Fragment>
    );
    }
}   
 export default withStyles(styles)(WeatherForecast);
