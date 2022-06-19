import React, { Component } from 'react'
import { Col, Container, Row } from 'reactstrap'

export default class Employee extends Component {
  render() {
    return (
      <div>
        <Container>
              <h4>Employee</h4>
          <Row>
            <Col lg="3">
              <div className="myCard">
              <img className="img-fluid" src="img/person_icon-icons.com_50075.png" />
              <h5>Orkhan Ganbarov</h5>
              <p className="mb-1">Age: 20</p>
              <p className="m-0">Position: IT</p>
              </div>
            </Col>
          </Row>
        </Container>
      </div>
    )
  }
}
