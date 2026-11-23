import React from "react";

type HeadingProps = {
  level: number;
  children: string | string[];
  className: string;
};

const Heading: React.FC<HeadingProps> = ({ level, children, className }) => {
  const Tag = `h${level}` as keyof JSX.IntrinsicElements;

  return <Tag className={className}>{children}</Tag>;
};

export default Heading;
