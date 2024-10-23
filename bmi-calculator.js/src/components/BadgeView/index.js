import React, { useCallback } from 'react';
import styled from 'styled-components';
import PropTypes from 'prop-types';
import variablesBreakpoints from '../../helpers/variablesBreakpoints';

const StyledBadge = styled.div`
  background-color: ${(props) => props.bgColor};
  margin-inline: ${(props) => props.marginX};
  margin-block: ${(props) => props.marginY};
  padding-inline: ${(props) => props.paddingX};
  padding-block: ${(props) => props.paddingY};
  border-radius: 10px;
  box-shadow: 0px 4px 4px ${variablesBreakpoints.shadowColor};
`;

function BadgeView({
  children,
  bgColor,
  marginX,
  marginY,
  paddingX,
  paddingY,
}) {
  return useCallback(
    <StyledBadge
      {...{
        children,
        bgColor,
        marginX,
        marginY,
        paddingX,
        paddingY,
      }}
    />,
    [children, bgColor, marginX, marginY, paddingX, paddingY]
  );
}

BadgeView.propTypes = {
  children: PropTypes.element.isRequired,
  bgColor: PropTypes.string,
  marginX: PropTypes.string,
  marginY: PropTypes.string,
  paddingX: PropTypes.string,
  paddingY: PropTypes.string,
};

BadgeView.defaultProps = {
  bgColor: variablesBreakpoints.primaryColor,
  marginX: '0px',
  marginY: '0px',
  paddingX: '15px',
  paddingY: '4px',
};

export default BadgeView;
