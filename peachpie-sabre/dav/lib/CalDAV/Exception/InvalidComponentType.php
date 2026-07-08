<?php


namespace Sabre\CalDAV\Exception;

use Sabre\CalDAV;
use Sabre\DAV;

/**
 * InvalidComponentType.
 *
 * @copyright Copyright (C) fruux GmbH (https://fruux.com/)
 * @author Evert Pot (http://evertpot.com/)
 * @license http://sabre.io/license/ Modified BSD License
 */
class InvalidComponentType extends DAV\Exception\Forbidden
{
    /**
     * Adds in extra information in the xml response.
     *
     * This method adds the {CALDAV:}supported-calendar-component as defined in rfc4791
     */
    public function serialize(DAV\Server $server, \Sabre\Xml\Writer $writer)
    {
        $writer->writeElement('{'.CalDAV\Plugin::NS_CALDAV.'}supported-calendar-component');
    }
}
