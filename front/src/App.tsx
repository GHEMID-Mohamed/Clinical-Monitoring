import {
  Container,
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { useQuery } from "react-query";
import { getClinics } from "./repository";
import LogoImg from "./assets/logo.png";

function App() {
  const { data } = useQuery("clinics", getClinics);

  return (
    <Container maxWidth="md">
      <Grid>
        <Grid item>
          <div
            style={{
              display: "flex",
              textAlign: "center",
              verticalAlign: "middle",
              alignItems: "center",
              marginTop: 20,
            }}
          >
            <span>
              <img src={LogoImg} />
            </span>
            <span style={{ fontWeight: "bold", fontSize: 20, marginLeft: 10 }}>
              Clinical Monitoring
            </span>
          </div>
        </Grid>
      </Grid>

      <br />
      <br />

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Nom</TableCell>
              <TableCell>Adresse</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data?.map((row) => (
              <TableRow
                key={row.name}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {row.name}
                </TableCell>
                <TableCell>{row.address}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Container>
  );
}

export default App;
